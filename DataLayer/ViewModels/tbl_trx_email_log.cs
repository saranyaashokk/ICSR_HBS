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
    
    public partial class tbl_trx_email_log
    {
        public long email_log_id { get; set; }
        public long reservationId { get; set; }
        public string from_mailId { get; set; }
        public string to_mailId { get; set; }
        public string cc1_mailId { get; set; }
        public string cc2_mailId { get; set; }
        public string cc3_mailId { get; set; }
        public string mail_subject { get; set; }
        public string mail_body { get; set; }
        public string attachment_file_name { get; set; }
        public Nullable<bool> is_active { get; set; }
        public Nullable<bool> is_reminder { get; set; }
        public Nullable<System.DateTime> createdTime { get; set; }
    
        public virtual tbl_trx_reservation tbl_trx_reservation { get; set; }
    }
}
