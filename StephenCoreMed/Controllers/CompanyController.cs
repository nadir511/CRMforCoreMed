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
    public class CompanyController : Controller
    {
        CompaniesUtilities CompanyU = new CompaniesUtilities();
        CustomerUtilities CcU = new CustomerUtilities();
        CoreMedEntities db = new CoreMedEntities();

        // GET: Company
        public ActionResult ComapniesList()
        {
            return View(CompanyU.CompanyList());
        }
        [HttpGet]
        public ActionResult CreateCompany()
        {
            return View();
        }
        public ActionResult searchCompanyEmployees(int? Id)
        {
            var CompanyName = db.Companies.Where(x => x.C_Id == Id).Select(x => x.C_Name).FirstOrDefault();
            ViewBag.companyName = CompanyName;
            return View(CcU.CompanyCustomerList(Id));
        }
        [HttpPost]
        public ActionResult CreateCompany(CompanyVM CreatecompanyVM)
        {
            if(ModelState.IsValid)
            {
                var CreateCompany = new Company()
                {
                    C_Name= CreatecompanyVM.C_Name,
                    C_Email= CreatecompanyVM.C_Email,
                    C_CellNumber= CreatecompanyVM.C_CellNumber,
                    C_PhoneNumber= CreatecompanyVM.C_PhoneNumber,
                    C_Website= CreatecompanyVM.C_Website,
                    C_Country= CreatecompanyVM.C_Country,
                    C_State= CreatecompanyVM.C_State,
                    C_City= CreatecompanyVM.C_City,
                    C_Address= CreatecompanyVM.C_Address,
                    C_Description= CreatecompanyVM.C_Description,
                    CreatedBy= User.Identity.Name,
                    CreatedDate=DateTime.Now
                };
                db.Companies.Add(CreateCompany);
                db.SaveChanges();
                return RedirectToAction("ComapniesList");
            }
            return View(CreatecompanyVM);
        }
        [HttpGet]
        public ActionResult EditCompany(int? Id)
        {
            CompanyVM Editcompany = db.Companies.Where(x => x.C_Id == Id).Select(x => new CompanyVM
            {
                C_Id=x.C_Id,
                C_Name=x.C_Name,
                C_Email=x.C_Email,
                C_CellNumber=x.C_CellNumber,
                C_PhoneNumber=x.C_PhoneNumber,
                C_Website=x.C_Website,
                C_Country=x.C_Country,
                C_State=x.C_State,
                C_City=x.C_City,
                C_Address=x.C_Address,
                C_Description=x.C_Description
            }).FirstOrDefault();
            return View(Editcompany);
        }
        [HttpPost]
        public ActionResult EditCompany(CompanyVM Editcompany)
        {
            if(ModelState.IsValid)
            {
                var EditableCompany = db.Companies.Where(x => x.C_Id == Editcompany.C_Id).FirstOrDefault();
                EditableCompany.C_Name = Editcompany.C_Name;
                EditableCompany.C_Email = Editcompany.C_Email;
                EditableCompany.C_CellNumber = Editcompany.C_CellNumber;
                EditableCompany.C_PhoneNumber = Editcompany.C_PhoneNumber;
                EditableCompany.C_Website = Editcompany.C_Website;
                EditableCompany.C_Country = Editcompany.C_Country;
                EditableCompany.C_State = Editcompany.C_State;
                EditableCompany.C_City = Editcompany.C_City;
                EditableCompany.C_Address = Editcompany.C_Address;
                EditableCompany.C_Description = Editcompany.C_Description;
                EditableCompany.UpdatedBy = User.Identity.Name;
                EditableCompany.UpdatedDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("ComapniesList");

            }
            return View(Editcompany);
        }
    }
}