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
    
    public partial class tbl_payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_payment()
        {
            this.tbl_receipt = new HashSet<tbl_receipt>();
        }
    
        public long paymentId { get; set; }
        public long reservationId { get; set; }
        public int mode_of_paymentId { get; set; }
        public string cheque_no_dd_no { get; set; }
        public string faculty_name { get; set; }
        public string department { get; set; }
        public long amount_paid { get; set; }
        public string amount_in_words { get; set; }
        public System.DateTime payment_date { get; set; }
        public Nullable<long> debited_account { get; set; }
        public Nullable<bool> is_full { get; set; }
        public Nullable<bool> is_receipt { get; set; }
        public Nullable<System.DateTime> createdTime { get; set; }
    
        public virtual tbl_mst_mode_of_payment tbl_mst_mode_of_payment { get; set; }
        public virtual tbl_trx_reservation tbl_trx_reservation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_receipt> tbl_receipt { get; set; }
    }
}
