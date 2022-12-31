using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StephenCoreMed.Models.ViewModels
{
    public class DocumentVM
    {
        public int D_Id { get; set; }
        [Required]
        [Display(Name = "Document Name")]
        public string D_Name { get; set; }
       
        public byte[] Document_File { get; set; }
        [Display(Name = "Document File")]
        public string FileName { get; set; }
        [Required]
        [Display(Name = "Document File")]
        public HttpPostedFileBase Files { get; set; }
        [Display(Name = "Company")]
        public Nullable<int> C_Id_FK { get; set; }
        [Display(Name = "Customer")]
        public Nullable<int> Customer_Id_FK { get; set; }
        public string Doc_Type { get; set; }
        public Nullable<System.DateTime> Doc_Offer_Date { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }

        public string WrittenBy { get; set; }

    }
}