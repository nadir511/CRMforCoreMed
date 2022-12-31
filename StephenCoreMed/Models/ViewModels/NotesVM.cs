using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StephenCoreMed.Models.ViewModels
{
    public class NotesVM
    {
        public int N_Id { get; set; }
        [Display(Name = "Title")]
        [Required]
        public string N_Topic { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string N_Discussion { get; set; }
        public bool IsDone { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> C_Id_FK { get; set; }
        public Nullable<int> Customer_Id_FK { get; set; }
    }
}