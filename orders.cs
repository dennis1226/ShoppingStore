//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _4915M_Project_P2
{
    using System;
    using System.Collections.Generic;
    
    public partial class orders
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ItemID { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public System.DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string DepartmentID { get; set; }
        public string showcaseID { get; set; }
    }
}
