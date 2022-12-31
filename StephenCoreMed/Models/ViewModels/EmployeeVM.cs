using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StephenCoreMed.Models.ViewModels
{
    public class EmployeeVM
    {
        public int Employee_Id { get; set; }
        [Display(Name = "Employee Name")]
        [Required]
        [StringLength(200, ErrorMessage = "Only 200 characters allowed", MinimumLength = 2)]
        public string Employee_Name { get; set; }
        [Display(Name = "Employee Title")]
        public string Employee_Title { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "Only 50 characters allowed", MinimumLength = 2)]

        public string Employee_Email { get; set; }
        [Display(Name = "Phone Number")]
        [StringLength(20, ErrorMessage = "Only 20 characters allowed", MinimumLength = 2)]

        public string Employee_PhoneNumber { get; set; }
        [Display(Name = "Cell Number")]
        [StringLength(20, ErrorMessage = "Only 20 characters allowed", MinimumLength = 2)]

        public string Employee_CellNumber { get; set; }
        [Display(Name = "Address")]
        [StringLength(500, ErrorMessage = "Only 500 characters allowed", MinimumLength = 2)]

        public string Employee_Address { get; set; }
        [StringLength(1000, ErrorMessage = "Only 1000 characters allowed", MinimumLength = 2)]

        public string Employee_Description { get; set; }
        [Display(Name = "City")]
        [RegularExpression(@"^[a-zA-Z0-9''_ ']+$", ErrorMessage = "Special character should not be entered")]
        [StringLength(100, ErrorMessage = "Only 100 characters allowed", MinimumLength = 2)]

        public string Employee_City { get; set; }
        [Display(Name = "State")]
        [RegularExpression(@"^[a-zA-Z0-9''_ ']+$", ErrorMessage = "Special character should not be entered")]
        [StringLength(100, ErrorMessage = "Only 100 characters allowed", MinimumLength = 2)]

        public string Employee_State { get; set; }
        [Display(Name = "Country")]
        [RegularExpression(@"^[a-zA-Z0-9''_ ']+$", ErrorMessage = "Special character should not be entered")]
        [StringLength(100, ErrorMessage = "Only 100 characters allowed", MinimumLength = 2)]

        public string Employee_Country { get; set; }
        
        public string EC_Type { get; set; }
        [Display(Name = "Department")]
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