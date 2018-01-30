namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_trx_email_log
    {
        [Key]
        public long email_log_id { get; set; }

        public long reservationId { get; set; }

        [Required]
        [StringLength(50)]
        public string from_mailId { get; set; }

        [Required]
        [StringLength(50)]
        public string to_mailId { get; set; }

        [StringLength(50)]
        public string cc1_mailId { get; set; }

        [StringLength(50)]
        public string cc2_mailId { get; set; }

        [StringLength(50)]
        public string cc3_mailId { get; set; }

        [StringLength(250)]
        public string mail_subject { get; set; }

        [StringLength(500)]
        public string mail_body { get; set; }

        [StringLength(100)]
        public string attachment_file_name { get; set; }

        public bool? is_active { get; set; }

        public bool? is_reminder { get; set; }

        public DateTime? createdTime { get; set; }

        public virtual tbl_trx_reservation tbl_trx_reservation { get; set; }
    }
}
