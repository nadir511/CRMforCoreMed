using StephenCoreMed.CommonUtilities;
using StephenCoreMed.Models;
using StephenCoreMed.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StephenCoreMed.Controllers
{
    [Authorize]
    public class MakeNotesController : Controller
    {
        // GET: MakeNotes
        CompaniesUtilities CompanyU = new CompaniesUtilities();
        CustomerUtilities CustomerU = new CustomerUtilities();

        CoreMedEntities db = new CoreMedEntities();

  
        [HttpGet]
        public ActionResult CreateNotes()
        {
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name");
            var CustomerList = CustomerU.CustomerList();
            ViewBag.CustomerList = new SelectList(CustomerList, "Customer_Id", "Customer_Name");


            NotesCombineVM notesCombineVM = new NotesCombineVM();
            List<NotesVM> ListNotes = db.Notes.Select(x => new NotesVM
            {
                N_Id=x.N_Id,
                N_Topic=x.N_Topic,
                N_Discussion=x.N_Discussion,
                IsDone=(bool)x.IsDone,
                CreatedBy=x.CreatedBy,
                CreatedDate=x.CreatedDate
            }).OrderByDescending(x=>x.N_Id).ToList();
            notesCombineVM.ListnotesVMs = new List<NotesVM>();
            notesCombineVM.ListnotesVMs.AddRange(ListNotes);
            return View(notesCombineVM);
        }
        [HttpGet]
        public ActionResult UpdateNotes(int? N_Id,bool? isDone)
        {
            var UpdatedStatus = db.Notes.Where(x => x.N_Id == N_Id).FirstOrDefault();
            UpdatedStatus.IsDone = isDone;
            UpdatedStatus.UpdatedBy = User.Identity.Name;
            UpdatedStatus.UpdatedDate = DateTime.Now;
            db.SaveChanges();
            return PartialView("_UpdateNotes");
        }
        [HttpPost]
        public ActionResult createNewNote(NotesCombineVM CreatenotesCombine)
        {
            
            var CreateNote = new Note()
            {
                N_Topic = CreatenotesCombine.NotesVM.N_Topic,
                N_Discussion = CreatenotesCombine.NotesVM.N_Discussion,
                Customer_Id_FK= CreatenotesCombine.NotesVM.Customer_Id_FK,
                C_Id_FK = CreatenotesCombine.NotesVM.C_Id_FK,
                IsDone = false,
                CreatedBy= User.Identity.Name,
                CreatedDate=DateTime.Now
            };
            db.Notes.Add(CreateNote);
            db.SaveChanges();
            return RedirectToAction("CreateNotes");
            
        }
        [HttpPost]
        public ActionResult LoadCustomers_Company()
        {
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name");
            var CustomerList = CustomerU.CustomerList();
            ViewBag.CustomerList = new SelectList(CustomerList, "Customer_Id", "Customer_Name");

            return Json("Test");
        }
        public ActionResult LoadCustomers(int? CompanyID)
        {
            var CustomerList = CustomerU.CustomerList().Where(x => x.C_ID_Fk == CompanyID).ToList();

            return Json(new SelectList(CustomerList, "Customer_Id", "Customer_Name"));
        }
    }
}