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

    public class CustomerController : Controller
    {
        CoreMedEntities db = new CoreMedEntities();
        CustomerUtilities CcU = new CustomerUtilities();
        CompaniesUtilities CompanyU = new CompaniesUtilities();
        // GET: Customer
        public ActionResult CustomerList()
        {

            return View(CcU.CustomerList());
        }
       
        [HttpGet]
        public ActionResult CreateCustomer()
        {
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name");
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomer(Customer_VM CreateCustomer)
        {
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name");
            if (ModelState.IsValid)
            {
                var CreateCustomerInfo = new Employee_Customer()
                {
                    CE_Title = CreateCustomer.Customer_Title,
                    CE_Name = CreateCustomer.Customer_Name,
                    C_ID_Fk = CreateCustomer.C_ID_Fk,
                    CE_CellNumber = CreateCustomer.Customer_CellNumber,
                    CE_PhoneNumber = CreateCustomer.Customer_PhoneNumber,
                    CE_Email = CreateCustomer.Customer_Email,
                    CE_Country = CreateCustomer.Customer_Country,
                    CE_State = CreateCustomer.Customer_State,
                    CE_City = CreateCustomer.Customer_City,
                    CE_Address = CreateCustomer.Customer_Address,
                    CE_Description = CreateCustomer.Customer_Description,
                    EC_Type = "Customer".Trim(),
                    CreatedBy = User.Identity.Name,
                    CreatedDate = DateTime.Now
                };
                db.Employee_Customer.Add(CreateCustomerInfo);
                db.SaveChanges();
                return RedirectToAction("CustomerList");
            }
            return View(CreateCustomer);
        }
        [HttpGet]
        public ActionResult EditCustomer(int? id)
        {

            Customer_VM customer_VM = db.Employee_Customer.Where(x => x.CE_Id == id).Select(x => new Customer_VM
            {
                Customer_Id=x.CE_Id,
                Customer_Title = x.CE_Title,
                Customer_Name = x.CE_Name,
                C_ID_Fk = x.C_ID_Fk,
                Customer_CellNumber = x.CE_CellNumber,
                Customer_PhoneNumber = x.CE_PhoneNumber,
                Customer_Email = x.CE_Email,
                Customer_Country = x.CE_Country,
                Customer_State = x.CE_State,
                Customer_City = x.CE_City,
                Customer_Address = x.CE_Address,
                Customer_Description = x.CE_Description,

            }).FirstOrDefault();
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name", customer_VM.C_ID_Fk);

            return View(customer_VM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(Customer_VM UpdateCustomer)
        {
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name");
            if (ModelState.IsValid)
            {
                var EditAbleCustomer = db.Employee_Customer.Where(x => x.CE_Id == UpdateCustomer.Customer_Id).FirstOrDefault();
                EditAbleCustomer.CE_Title = UpdateCustomer.Customer_Title;
                EditAbleCustomer.CE_Name = UpdateCustomer.Customer_Name;
                EditAbleCustomer.C_ID_Fk = UpdateCustomer.C_ID_Fk;
                EditAbleCustomer.CE_CellNumber = UpdateCustomer.Customer_CellNumber;
                EditAbleCustomer.CE_PhoneNumber = UpdateCustomer.Customer_PhoneNumber;
                EditAbleCustomer.CE_Email = UpdateCustomer.Customer_Email;
                EditAbleCustomer.CE_Country = UpdateCustomer.Customer_Country;
                EditAbleCustomer.CE_State = UpdateCustomer.Customer_State;
                EditAbleCustomer.CE_City = UpdateCustomer.Customer_City;
                EditAbleCustomer.CE_Address = UpdateCustomer.Customer_Address;
                EditAbleCustomer.CE_Description = UpdateCustomer.Customer_Description;
                EditAbleCustomer.UpdatedBy = User.Identity.Name;
                EditAbleCustomer.UpdatedDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("CustomerList");
            }
            return View(UpdateCustomer);
        }
    }
}