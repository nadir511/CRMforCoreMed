//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StephenCoreMed.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Document
    {
        public int D_Id { get; set; }
        public string D_Name { get; set; }
        public byte[] D_File { get; set; }
        public string D_Original_Name { get; set; }
        public Nullable<int> C_Id_FK { get; set; }
        public Nullable<int> Customer_Id_FK { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Doc_Type { get; set; }
        public Nullable<System.DateTime> Doc_Offer_Date { get; set; }
        public string Doc_Number { get; set; }
        public string Doc_Writer_LoggedIn { get; set; }
        public string Doc_Writer_EnterByUser { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Employee_Customer Employee_Customer { get; set; }
    }
}
