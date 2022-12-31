using StephenCoreMed.Models;
using StephenCoreMed.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StephenCoreMed.CommonUtilities
{
    public class CompaniesUtilities
    {
        CoreMedEntities db = new CoreMedEntities();

        public List<CompanyVM> CompanyList()
        {
            List<CompanyVM> companyList = db.Companies.Select(x => new CompanyVM
            {
                C_Id=x.C_Id,
                C_Name=x.C_Name,
                C_Email=x.C_Email,
                C_City=x.C_City,
                C_CellNumber=x.C_CellNumber,
                C_PhoneNumber=x.C_PhoneNumber,
                C_Address=x.C_Address,
                C_Description=x.C_Description
            }).OrderByDescending(x => x.C_Id).ToList();
            return companyList;
        }
    }
}