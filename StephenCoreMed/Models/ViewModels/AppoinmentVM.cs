using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StephenCoreMed.Models.ViewModels
{
    public class AppoinmentVM
    {
        public int A_ID { get; set; }
        [Display(Name = "Appointment Title")]
        [Required]
        [StringLength(500, ErrorMessage = "Minimum 2 and Maximum 500 characters Allowed", MinimumLength = 2)]
        public string A_Title { get; set; }
        [StringLength(1000, ErrorMessage = "Minimum 2 and Maximum 1000 characters Allowed", MinimumLength = 2)]
        [Display(Name = "Description")]
        [Required]
        public string A_Description { get; set; }
        [Display(Name = "Date")]
        [Required]
        public Nullable<System.DateTime> A_Date { get; set; }
        [Display(Name = "Company")]
        public Nullable<int> C_Id_FK { get; set; }
        [Display(Name = "Customer")]
        public Nullable<int> CE_Id_FK { get; set; }
        public string CreatedBY { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string CompanyName { get; set; }

        public string CustomerName { get; set; }
        //[Display(Name = "Appointment Creator")]
        //[Required]
        //public Nullable<int> Employee_Id { get; set; }
        
        public string App_CraetedBy { get; set; }


    }
}