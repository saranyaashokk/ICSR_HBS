namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_payment()
        {
            tbl_receipt = new HashSet<tbl_receipt>();
        }

        [Key]
        public long paymentId { get; set; }

        public long reservationId { get; set; }

        public int mode_of_paymentId { get; set; }

        [Column("cheque_no/dd_no")]
        [StringLength(50)]
        public string cheque_no_dd_no { get; set; }

        [Required]
        [StringLength(100)]
        public string faculty_name { get; set; }

        [Required]
        [StringLength(250)]
        public string department { get; set; }

        public long amount_paid { get; set; }

        [Column("amount in words")]
        [Required]
        [StringLength(250)]
        public string amount_in_words { get; set; }

        public DateTime payment_date { get; set; }

        public long? debited_account { get; set; }

        public bool? is_full { get; set; }

        public bool? is_receipt { get; set; }

        public DateTime? createdTime { get; set; }

        public virtual tbl_mst_mode_of_payment tbl_mst_mode_of_payment { get; set; }

        public virtual tbl_trx_reservation tbl_trx_reservation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_receipt> tbl_receipt { get; set; }
    }
}
