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
    
    public partial class Appointment
    {
        public int A_ID { get; set; }
        public string A_Title { get; set; }
        public string A_Description { get; set; }
        public Nullable<System.DateTime> A_Date { get; set; }
        public Nullable<int> C_Id_FK { get; set; }
        public Nullable<int> CE_Id_FK { get; set; }
        public string CreatedBY { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Employee_Customer Employee_Customer { get; set; }
    }
}
