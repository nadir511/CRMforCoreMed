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

    public class AppointmentController : Controller
    {
        CompaniesUtilities CompanyU = new CompaniesUtilities();
        CustomerUtilities CustomerU = new CustomerUtilities();
        CoreMedEntities db = new CoreMedEntities();
        EmployeeUtility EmployeeU = new EmployeeUtility();

        // GET: Appointment
        public ActionResult AppointmentList()
        {
            List<AppoinmentVM> AppointmentList = db.Appointments.Select(x => new AppoinmentVM
            {
                A_ID=x.A_ID,
                A_Title=x.A_Title,
                A_Date=x.A_Date,
                CompanyName= db.Companies.Where(y => y.C_Id == x.C_Id_FK).Select(y => y.C_Name).FirstOrDefault(),
                CustomerName=db.Employee_Customer.Where(y=>y.CE_Id==x.CE_Id_FK).Select(y=>y.CE_Name).FirstOrDefault(),
                A_Description=x.A_Description,
                CreatedBY=x.CreatedBY
            }).OrderByDescending(x => x.A_ID).ToList();
            return View(AppointmentList);
        }
        [HttpGet]
        public ActionResult CreateAppointment()
        {
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name");
            var CustomerList = CustomerU.CustomerList();
            ViewBag.CustomerList = new SelectList(CustomerList, "Customer_Id", "Customer_Name");

            var EmployeeList = EmployeeU.EmployeeList();
            ViewBag.EmployeeList = new SelectList(EmployeeList, "Employee_Id", "Employee_Name");

            return View();
        }
        [HttpPost]
        public ActionResult CreateAppointment(AppoinmentVM CreateappoinmentVM)
        {
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name");
            var CustomerList = CustomerU.CustomerList();
            ViewBag.CustomerList = new SelectList(CustomerList, "Customer_Id", "Customer_Name");

            var EmployeeList = EmployeeU.EmployeeList();
            ViewBag.EmployeeList = new SelectList(EmployeeList, "Employee_Id", "Employee_Name");

            if (ModelState.IsValid)
            {
                var CreateAppointment = new Appointment()
                {
                A_Title= CreateappoinmentVM.A_Title,
                A_Date= CreateappoinmentVM.A_Date,
                CE_Id_FK= CreateappoinmentVM.CE_Id_FK,
                C_Id_FK= CreateappoinmentVM.C_Id_FK,
                A_Description= CreateappoinmentVM.A_Description,
                CreatedBY =User.Identity.Name,
                CreatedDate=DateTime.Now
                };
                db.Appointments.Add(CreateAppointment);
                db.SaveChanges();
                return RedirectToAction("AppointmentList");
            }

            return View(CreateappoinmentVM);
        }
        [HttpGet]
        public ActionResult EditAppointment(int? id)
        {
            AppoinmentVM appoinmentData = db.Appointments.Where(x => x.A_ID == id).Select(x => new AppoinmentVM
            {
                A_Title=x.A_Title,
                A_Date=x.A_Date,
                CE_Id_FK=x.CE_Id_FK,
                C_Id_FK=x.C_Id_FK,
                A_Description=x.A_Description,
                A_ID=x.A_ID,
            }).FirstOrDefault();
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name", appoinmentData.C_Id_FK);
            var CustomerList = CustomerU.CustomerList();
            ViewBag.CustomerList = new SelectList(CustomerList, "Customer_Id", "Customer_Name", appoinmentData.CE_Id_FK);

            var EmployeeList = EmployeeU.EmployeeList();
            ViewBag.EmployeeList = new SelectList(EmployeeList, "Employee_Id", "Employee_Name");
            return View(appoinmentData);
        }
        [HttpPost]
        public ActionResult EditAppointment(AppoinmentVM UpdateAppointment)
        {
            var CompanyList = CompanyU.CompanyList();
            ViewBag.CompanyList = new SelectList(CompanyList, "C_ID", "C_Name");
            var CustomerList = CustomerU.CustomerList();
            ViewBag.CustomerList = new SelectList(CustomerList, "Customer_Id", "Customer_Name");
            var EmployeeList = EmployeeU.EmployeeList();
            ViewBag.EmployeeList = new SelectList(EmployeeList, "Employee_Id", "Employee_Name");
            if (ModelState.IsValid) 
            {
                var Updated = db.Appointments.Where(x => x.A_ID == UpdateAppointment.A_ID).FirstOrDefault();
                Updated.A_Title = UpdateAppointment.A_Title;
                Updated.A_Date = UpdateAppointment.A_Date;
                Updated.CE_Id_FK = UpdateAppointment.CE_Id_FK;
                Updated.C_Id_FK = UpdateAppointment.C_Id_FK;
                Updated.A_Description = UpdateAppointment.A_Description;
                Updated.UpdatedBy = User.Identity.Name;
                Updated.UpdatedOn = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("AppointmentList");
            }
            return View(UpdateAppointment);
        }

        public ActionResult LoadCustomers(int? CompanyID)
        {
            var CustomerList = CustomerU.CustomerList().Where(x=>x.C_ID_Fk== CompanyID).ToList();

            return Json(new SelectList(CustomerList, "Customer_Id", "Customer_Name"));
        }
    }
}