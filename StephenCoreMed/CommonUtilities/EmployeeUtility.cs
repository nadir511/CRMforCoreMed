using StephenCoreMed.Models;
using StephenCoreMed.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StephenCoreMed.CommonUtilities
{
    public class EmployeeUtility
    {
        CoreMedEntities db = new CoreMedEntities();
        public List<EmployeeVM> EmployeeList()
        {
            List<EmployeeVM> EmployeeList = db.Employee_Customer.Where(x => x.EC_Type == "Employee".Trim()).Select(x => new EmployeeVM
            {
                Employee_Id = x.CE_Id,
                Employee_Title = x.CE_Title,
                Employee_Name = x.CE_Name,
                Employee_CellNumber = x.CE_CellNumber,
                Employee_Email = x.CE_Email,
                Employee_City = x.CE_City,
                Employee_Address = x.CE_Address,
            }).OrderByDescending(x => x.Employee_Id).ToList();
            return EmployeeList;
        }
    }
}