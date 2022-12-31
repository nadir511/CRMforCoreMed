using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StephenCoreMed.Models.ViewModels
{
    public class CompanyVM
    {
        public int C_Id { get; set; }
        [Display(Name = "Company Name")]
        [Required]
        [StringLength(200, ErrorMessage = "Only 200 characters allowed", MinimumLength = 2)]
        public string C_Name { get; set; }
        [Display(Name = "Address")]
        [StringLength(500, ErrorMessage = "Only 500 characters allowed", MinimumLength = 2)]

        public string C_Address { get; set; }
        [Display(Name = "Phone Number")]
        [StringLength(20, ErrorMessage = "Only 20 characters allowed", MinimumLength = 2)]

        public string C_PhoneNumber { get; set; }
        [Display(Name = "Cell Number")]
        [StringLength(20, ErrorMessage = "Only 20 characters allowed", MinimumLength = 2)]
        public string C_CellNumber { get; set; }
        
        [Display(Name = "City")]
        [StringLength(150, ErrorMessage = "Only 150 characters allowed", MinimumLength = 2)]

        public string C_City { get; set; }
        [Display(Name = "State")]
        [StringLength(150, ErrorMessage = "Only 150 characters allowed", MinimumLength = 2)]

        public string C_State { get; set; }
        [Display(Name = "Country")]
        [StringLength(150, ErrorMessage = "Only 150 characters allowed", MinimumLength = 2)]

        public string C_Country { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "Only 50 characters allowed", MinimumLength = 2)]

        public string C_Email { get; set; }
        [Display(Name = "WebSite")]
        [StringLength(50, ErrorMessage = "Only 50 characters allowed", MinimumLength = 2)]

        public string C_Website { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        [StringLength(1000, ErrorMessage = "Only 1000 characters allowed", MinimumLength = 2)]

        public string C_Description { get; set; }

    }
}