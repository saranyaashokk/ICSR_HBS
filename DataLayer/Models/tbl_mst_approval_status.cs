namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_mst_approval_status
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_mst_approval_status()
        {
            tbl_trx_booking_timeSlot = new HashSet<tbl_trx_booking_timeSlot>();
            tbl_trx_reservation = new HashSet<tbl_trx_reservation>();
        }

        [Key]
        public int approval_statusId { get; set; }

        [Required]
        [StringLength(100)]
        public string approval_status { get; set; }

        [Required]
        [StringLength(50)]
        public string approval_status_color { get; set; }

        public bool? is_active { get; set; }

        public DateTime? createdTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_trx_booking_timeSlot> tbl_trx_booking_timeSlot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_trx_reservation> tbl_trx_reservation { get; set; }
    }
}
