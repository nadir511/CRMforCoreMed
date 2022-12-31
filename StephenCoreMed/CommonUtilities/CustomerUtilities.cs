using StephenCoreMed.Models;
using StephenCoreMed.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace StephenCoreMed.CommonUtilities
{
    public class CustomerUtilities
    {
        CoreMedEntities db = new CoreMedEntities();

        public List<Customer_VM> CustomerList()
        {
            List<Customer_VM> customerList = db.Employee_Customer.Where(x=>x.EC_Type== "Customer".Trim()).Select(x => new Customer_VM
            {
                Customer_Id=x.CE_Id,
                Customer_Title = x.CE_Title,
                Customer_Name = x.CE_Name,
                CompanyName = db.Companies.Where(y=>y.C_Id==x.C_ID_Fk).Select(y=>y.C_Name).FirstOrDefault(),
                Customer_CellNumber = x.CE_CellNumber,
                Customer_PhoneNumber=x.CE_PhoneNumber,
                Customer_Email = x.CE_Email,
                Customer_City = x.CE_City,
                Customer_Address=x.CE_Address,
                C_ID_Fk=x.C_ID_Fk
                
            }).OrderByDescending(x => x.Customer_Id).ToList();
            return customerList;
        }
        public List<Customer_VM> CompanyCustomerList(int? CompanyId)
        {
            
            List<Customer_VM> customerList = db.Employee_Customer.Where(x => x.EC_Type == "Customer".Trim() && x.C_ID_Fk== CompanyId).Select(x => new Customer_VM
            {
                Customer_Id = x.CE_Id,
                Customer_Title = x.CE_Title,
                Customer_Name = x.CE_Name,
                CompanyName = db.Companies.Where(y => y.C_Id == x.C_ID_Fk).Select(y => y.C_Name).FirstOrDefault(),
                Customer_CellNumber = x.CE_CellNumber,
                Customer_PhoneNumber = x.CE_PhoneNumber,
                Customer_Email = x.CE_Email,
                Customer_City = x.CE_City,
                Customer_Address = x.CE_Address,
                C_ID_Fk = x.C_ID_Fk

            }).OrderByDescending(x => x.Customer_Id).ToList();
            return customerList;
        }

    }
}