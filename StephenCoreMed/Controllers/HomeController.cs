using StephenCoreMed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StephenCoreMed.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        CoreMedEntities db = new CoreMedEntities();

        public ActionResult Index()
        {
            ViewBag.TotalCustomers = db.Employee_Customer.Where(x => x.EC_Type == "Customer").Count();
            ViewBag.TotalEmployes = db.Employee_Customer.Where(x => x.EC_Type != "Customer").Count();
            ViewBag.TotalCompanies = db.Companies.Count();
            ViewBag.TotalDocuments = db.Documents.Count();

            return View();
        }
    }
}