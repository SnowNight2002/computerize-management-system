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
    
    public partial class goods_returned_note
    {
        public string Goods_Returned_Note_Number { get; set; }
        public string Company_Name { get; set; }
        public string EmpID { get; set; }
        public string Returner { get; set; }
        public Nullable<System.DateTime> Return_Date { get; set; }
        public string ItemName { get; set; }
        public Nullable<double> Amounts { get; set; }
        public string item_Return_Reason { get; set; }
        public Nullable<double> Amount_of_Money_Returned { get; set; }
    
        public virtual empolyee empolyee { get; set; }
    }
}
