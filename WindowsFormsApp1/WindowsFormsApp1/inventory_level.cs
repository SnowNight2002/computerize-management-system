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
    
    public partial class inventory_level
    {
        public int StockID { get; set; }
        public string StockName { get; set; }
        public string StockType { get; set; }
        public string StockBrand { get; set; }
        public string StockStatus { get; set; }
        public Nullable<short> StockQuantity { get; set; }
        public Nullable<short> StockMaxNumber { get; set; }
        public string EmpID { get; set; }
        public Nullable<int> RefillLevel { get; set; }
    
        public virtual empolyee empolyee { get; set; }
    }
}
