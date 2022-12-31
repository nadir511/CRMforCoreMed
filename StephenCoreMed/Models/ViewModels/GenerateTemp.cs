using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StephenCoreMed.Models.ViewModels
{
    public class GenerateTemp
    {
        public int D_Id { get; set; }
        [Required]
        [Display(Name = "Document Name")]
        public string D_Name { get; set; }
        [Display(Name = "Document File")]
        public byte[] Document_File { get; set; }
        [Display(Name = "Document File")]
        public string FileName { get; set; }
        [Display(Name = "Document File")]
        public HttpPostedFileBase Files { get; set; }
        [Display(Name = "Company")]
        public Nullable<int> C_Id_FK { get; set; }
        [Display(Name = "Customer")]
        public Nullable<int> Customer_Id_FK { get; set; }
        public string Doc_Type { get; set; }
        public Nullable<System.DateTime> Doc_Offer_Date { get; set; }

        public string Doc_Writer_NameByUser { get; set; }
        public string Doc_Writer_LoggedInUser { get; set; }


        public string Doc_Number { get; set; }


    }
}