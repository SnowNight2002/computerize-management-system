//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class payment
    {
        public payment()
        {
            this.deposit_receipt = new HashSet<deposit_receipt>();
            this.payment_receipt = new HashSet<payment_receipt>();
        }
    
        public string Order_ID { get; set; }
        public string Payment1 { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public string EmpID { get; set; }
        public string PaymentMethod { get; set; }
        public string Region { get; set; }
        public Nullable<double> TotalPrice { get; set; }
    
        public virtual ICollection<deposit_receipt> deposit_receipt { get; set; }
        public virtual empolyee empolyee { get; set; }
        public virtual ICollection<payment_receipt> payment_receipt { get; set; }
    }
}