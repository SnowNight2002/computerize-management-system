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
    
    public partial class payment_receipt
    {
        public string Order_ID { get; set; }
        public int itemsID { get; set; }
        public string Items_Name { get; set; }
        public int Quantity { get; set; }
        public Nullable<double> Item_Price { get; set; }
        public Nullable<double> Payment_amounts { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
    
        public virtual payment payment { get; set; }
        public virtual product product { get; set; }
    }
}