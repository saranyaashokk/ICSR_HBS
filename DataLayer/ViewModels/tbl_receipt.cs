//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.ViewModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_receipt
    {
        public long receiptId { get; set; }
        public long paymentId { get; set; }
        public System.DateTime receipt_date { get; set; }
        public Nullable<System.DateTime> createdTime { get; set; }
    
        public virtual tbl_payment tbl_payment { get; set; }
    }
}
