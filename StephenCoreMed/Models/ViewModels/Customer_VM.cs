using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StephenCoreMed.Models.ViewModels
{
    public class Customer_VM
    {
        public int Customer_Id { get; set; }
        [Display(Name = "Employee Name")]
        [Required]
        [StringLength(200, ErrorMessage = "Only 200 characters allowed", MinimumLength = 2)]
        public string Customer_Name { get; set; }
        [Display(Name = "Customer Title")]
        public string Customer_Title { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        public string Customer_Email { get; set; }
        [Display(Name = "Phone Number")]
        public string Customer_PhoneNumber { get; set; }
        [Display(Name = "Cell Number")]
        public string Customer_CellNumber { get; set; }
        [Display(Name = "Address")]
        public string Customer_Address { get; set; }
        public string Customer_Description { get; set; }
        [Display(Name = "City")]
        [RegularExpression(@"^[a-zA-Z0-9''_ ']+$", ErrorMessage = "Special character should not be entered")]
        public string Customer_City { get; set; }
        [Display(Name = "State")]
        [RegularExpression(@"^[a-zA-Z0-9''_ ']+$", ErrorMessage = "Special character should not be entered")]
        public string Customer_State { get; set; }
        [Display(Name = "Country")]
        [RegularExpression(@"^[a-zA-Z0-9''_ ']+$", ErrorMessage = "Special character should not be entered")]
        public string Customer_Country { get; set; }
        [Display(Name = "Company")]
        [Required]
        public Nullable<int> C_ID_Fk { get; set; }
        public string EC_Type { get; set; }
        
        //For Employee
        public string DepartmentName { get; set; }
        //For Company
        public string CompanyName { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}