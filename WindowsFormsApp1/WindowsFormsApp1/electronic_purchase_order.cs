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
    
    public partial class electronic_purchase_order
    {
        public electronic_purchase_order()
        {
            this.goods_received_note = new HashSet<goods_received_note>();
        }
    
        public string EPOrderID { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public string EmpID { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
    
        public virtual empolyee empolyee { get; set; }
        public virtual ICollection<goods_received_note> goods_received_note { get; set; }
        public virtual purchase_order_detail purchase_order_detail { get; set; }
    }
}
