using StephenCoreMed.Models;
using StephenCoreMed.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StephenCoreMed.CommonUtilities;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace StephenCoreMed.Controllers
{
    [Authorize]

    public class DocumentController : Controller
    {
        CoreMedEntities db = new CoreMedEntities();
        CompaniesUtilities CompanyU = new CompaniesUtilities();
        CustomerUtilities CustomerU = new CustomerUtilities();
        EmployeeUtility EmployeeU = new EmployeeUtility();
        // GET: Document

        [HttpGet]
        public ActionResult UploadDocument()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadDocument(DocumentVM UploaddocumentVM)
        {
            var ChkName = db.Documents.Where(x => x.D_Name == UploaddocumentVM.D_Name).Select(x => x.D_Name).FirstOrDefault();
            if (ChkName != null)
            {
                ModelState.AddModelError("D_Name", "Document With This Name Already Exist");
                return View(UploaddocumentVM);

            }

            if (ModelState.IsValid)
            {
                String FileExt = Path.GetExtension(UploaddocumentVM.Files.FileName).ToUpper();

                if (FileExt == ".DOCX" || FileExt == ".DOC" || FileExt == ".PDF" || FileExt == ".XLS" || FileExt == ".XLSX")
                {

                    Byte[] data = new byte[UploaddocumentVM.Files.ContentLength];
                    UploaddocumentVM.Files.InputStream.Read(data, 0, UploaddocumentVM.Files.ContentLength);
                    UploaddocumentVM.FileName = UploaddocumentVM.Files.FileName;
                    var SaveDoc = new Document()
                    {
                        D_Name = UploaddocumentVM.D_Name.Trim(),
                        D_File = data,
                        D_Original_Name = UploaddocumentVM.FileName,
                        CreatedBy = User.Identity.Name,
                        CreatedDate = DateTime.Now,
                        Doc_Type = "Uploaded"
                    };
                    db.Documents.Add(SaveDoc);
                    db.SaveChanges();
                    return RedirectToAction("DocumentLists");

                }
                else
                {
                    ModelState.AddModelError("Files", "Uploaded File Formate Should be Word Document(.DOCX) or Excel (.xls) or PDF");
                    return View(UploaddocumentVM);
                }
            }
            return View(UploaddocumentVM);
        }
        public ActionResult DocumentLists()
        {
            List<DocumentVM> ListOfDoc = db.Documents.Select(x => new DocumentVM
            {
                D_Name = x.D_Name,
                D_Id = x.D_Id,
                CompanyName= db.Companies.Where(y => y.C_Id == x.C_Id_FK).Select(y => y.C_Name).FirstOrDefault(),
                CustomerName= db.Employee_Customer.Where(y => y.CE_Id == x.Customer_Id_FK).Select(y => y.CE_Name).FirstOrDefault(),
                WrittenBy= x.Doc_Writer_LoggedIn,
            }).OrderByDescending(x => x.D_Id).ToList();
            return View(ListOfDoc);
        }
        [HttpGet]
        public FileResult DownloadDoc(int id)
        {
            var FileById = (from doc in db.Documents
                            where doc.D_Id.Equals(id)
                            select new { doc.D_Name, doc.D_File, doc.D_Original_Name }).ToList().FirstOrDefault();
            return File(FileById.D_File, System.Net.Mime.MediaTypeNames.Application.Octet, FileById.D_Original_Name);
        }
        [HttpGet]
        public ActionResult RemoveDoc(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
            db.SaveChanges();
            return RedirectToAction("DocumentLists");
        }
        [HttpGet]
        public ActionResult CreateDocument()
        {
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name");
            var CustomerList = CustomerU.CustomerList();
            ViewBag.CustomerList = new SelectList(CustomerList, "Customer_Id", "Customer_Name");
            var EmployeeList = EmployeeU.EmployeeList();
            ViewBag.EmployeeList = new SelectList(EmployeeList, "Employee_Id", "Employee_Name");
            var DocTempList = db.Documents.Where(x => x.Doc_Type == "Uploaded").ToList();
            ViewBag.DocTempList = new SelectList(DocTempList, "D_Id", "D_Name");

            return View();
        }
        [HttpPost]
        public ActionResult CreateDocument(GenerateTemp generateDoc)
        {
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name");
            var CustomerList = CustomerU.CustomerList();
            ViewBag.CustomerList = new SelectList(CustomerList, "Customer_Id", "Customer_Name");
            var EmployeeList = EmployeeU.EmployeeList();
            ViewBag.EmployeeList = new SelectList(EmployeeList, "Employee_Id", "Employee_Name");
            var DocTempList = db.Documents.Where(x=>x.Doc_Type== "Uploaded").ToList();
            ViewBag.DocTempList = new SelectList(DocTempList, "D_Id", "D_Name");
            if (ModelState.IsValid)
            {
                var FileById = (from doc in db.Documents
                                where doc.D_Id.Equals(generateDoc.D_Id)
                                select new { doc.D_File }).ToList().FirstOrDefault();
                using (var stream = new MemoryStream(FileById.D_File))
                {
                    using (WordDocument document = new WordDocument(stream, FormatType.Automatic))
                    {
                        var CompanyName = db.Companies.Where(x => x.C_Id == generateDoc.C_Id_FK).Select(x => x.C_Name).FirstOrDefault();
                        var CustomerName = db.Employee_Customer.Where(x => x.CE_Id == generateDoc.Customer_Id_FK).Select(x => x.CE_Name).FirstOrDefault();
                        var DocNumber = db.Documents.Max(x => x.D_Id);
                        var Date = generateDoc.Doc_Offer_Date;
                        var Docwriter = "";
                        if (generateDoc.Doc_Writer_NameByUser.TrimStart().TrimEnd() == null)
                        {
                            Docwriter = User.Identity.Name;
                        }
                        else
                        {
                            Docwriter=generateDoc.Doc_Writer_NameByUser;

                        };
                        
                        string[] fieldNames = { "Företagsnamn", "Köparens namn", "Datum", "Dokumentnummer", "Författare" };
                        string[] fieldValues = { CompanyName, CustomerName, Date.ToString(), (DocNumber+1).ToString(), Docwriter };
                        //Performs the mail merge
                        document.MailMerge.Execute(fieldNames, fieldValues);
                        //Saves the Word document to disk in DOCX format
                        document.Save("Result.docx", FormatType.Automatic, HttpContext.ApplicationInstance.Response, HttpContentDisposition.Attachment);
                        MemoryStream outStream = new MemoryStream();
                        document.Save(outStream, FormatType.Docx);
                        byte[] docBytes = outStream.ToArray();

                        var SaveDoc = new Document()
                        {
                            D_Name = generateDoc.D_Name.Trim(),
                            D_Original_Name = generateDoc.D_Name.Trim() + ".docx".Trim(),
                            D_File = docBytes,
                            C_Id_FK = db.Companies.Where(x => x.C_Id == generateDoc.C_Id_FK).Select(x => x.C_Id).FirstOrDefault(),
                            Customer_Id_FK = db.Employee_Customer.Where(x => x.CE_Id == generateDoc.Customer_Id_FK).Select(x => x.CE_Id).FirstOrDefault(),
                            CreatedBy = User.Identity.Name,
                            CreatedDate = DateTime.Now,
                            Doc_Type = "Generated",
                            Doc_Offer_Date = generateDoc.Doc_Offer_Date,
                            Doc_Number = generateDoc.Doc_Number,
                            Doc_Writer_LoggedIn = User.Identity.Name

                        };
                        db.Documents.Add(SaveDoc);
                        db.SaveChanges();
                        return RedirectToAction("DocumentLists");
                    }
                }
            }
            return View(generateDoc);

        }
        public ActionResult LoadCustomers(int? CompanyID)
        {
            var CustomerList = CustomerU.CustomerList().Where(x => x.C_ID_Fk == CompanyID).ToList();

            return Json(new SelectList(CustomerList, "Customer_Id", "Customer_Name"));
        }
    }
}