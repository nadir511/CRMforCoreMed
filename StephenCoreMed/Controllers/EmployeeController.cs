using StephenCoreMed.CommonUtilities;
using StephenCoreMed.Models;
using StephenCoreMed.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StephenCoreMed.CommonUtilities;

namespace StephenCoreMed.Controllers
{
    [Authorize]

    public class EmployeeController : Controller
    {
        CoreMedEntities db = new CoreMedEntities();
        EmployeeUtility Eu = new EmployeeUtility();
        // GET: Employee
        public ActionResult EmployeeList()
        {
          
            return View(Eu.EmployeeList());
        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            
            return View();
            
        }
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeVM CreateEmployee_VM)
        {
           
            if (ModelState.IsValid)
            {
                var CreateEmployeeInfo = new Employee_Customer()
                {
                    CE_Title = CreateEmployee_VM.Employee_Title,
                    CE_Name = CreateEmployee_VM.Employee_Name,
                    DepartmentName = CreateEmployee_VM.DepartmentName,
                    CE_CellNumber = CreateEmployee_VM.Employee_CellNumber,
                    CE_PhoneNumber = CreateEmployee_VM.Employee_PhoneNumber,
                    CE_Email = CreateEmployee_VM.Employee_Email,
                    CE_Country = CreateEmployee_VM.Employee_Country,
                    CE_State = CreateEmployee_VM.Employee_State,
                    CE_City = CreateEmployee_VM.Employee_City,
                    CE_Address = CreateEmployee_VM.Employee_Address,
                    CE_Description = CreateEmployee_VM.Employee_Description,
                    EC_Type = "Employee".Trim(),
                    CreatedBy = User.Identity.Name,
                    CreatedDate = DateTime.Now
                };
                db.Employee_Customer.Add(CreateEmployeeInfo);
                db.SaveChanges();
                return RedirectToAction("EmployeeList");
            }
            return View(CreateEmployee_VM);
        }
        [HttpGet]
        public ActionResult EditEmployee(int ? Id)
        {
            EmployeeVM employee_VM = db.Employee_Customer.Where(x => x.CE_Id == Id).Select(x => new EmployeeVM
            {
                Employee_Id = x.CE_Id,
                Employee_Title = x.CE_Title,
                Employee_Name = x.CE_Name,
                DepartmentName = x.DepartmentName,
                Employee_CellNumber = x.CE_CellNumber,
                Employee_PhoneNumber = x.CE_PhoneNumber,
                Employee_Email = x.CE_Email,
                Employee_Country = x.CE_Country,
                Employee_State = x.CE_State,
                Employee_City = x.CE_City,
                Employee_Address = x.CE_Address,
                Employee_Description = x.CE_Description,

            }).FirstOrDefault();
           

            return View(employee_VM);
        }
        public ActionResult EditEmployee(EmployeeVM EditEmployee_VM)
        {
            
            if (ModelState.IsValid) { 
            var EditableEmployee = db.Employee_Customer.Where(x => x.CE_Id == EditEmployee_VM.Employee_Id).FirstOrDefault();
            EditableEmployee.CE_Title = EditEmployee_VM.Employee_Title;
            EditableEmployee.CE_Name = EditEmployee_VM.Employee_Name;
            EditableEmployee.DepartmentName = EditEmployee_VM.DepartmentName;
            EditableEmployee.CE_CellNumber = EditEmployee_VM.Employee_CellNumber;
            EditableEmployee.CE_PhoneNumber = EditEmployee_VM.Employee_PhoneNumber;
            EditableEmployee.CE_Email = EditEmployee_VM.Employee_Email;
            EditableEmployee.CE_Country = EditEmployee_VM.Employee_Country;
            EditableEmployee.CE_State = EditEmployee_VM.Employee_State;
            EditableEmployee.CE_City = EditEmployee_VM.Employee_City;
            EditableEmployee.CE_Address = EditEmployee_VM.Employee_Address;
            EditableEmployee.CE_Description = EditEmployee_VM.Employee_Description;
            EditableEmployee.UpdatedBy = User.Identity.Name;
            EditableEmployee.UpdatedDate = DateTime.Now;
            db.SaveChanges();
            
                
            return RedirectToAction("EmployeeList");
            }

            return View(EditEmployee_VM);
        }
    }
}