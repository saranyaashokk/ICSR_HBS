namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_halls
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_halls()
        {
            tbl_trx_booking_timeSlot = new HashSet<tbl_trx_booking_timeSlot>();
            tbl_trx_reservation = new HashSet<tbl_trx_reservation>();
        }

        [Key]
        public int hallId { get; set; }

        [Required]
        [StringLength(100)]
        public string hallName { get; set; }

        public int? hall_capacity { get; set; }

        public int floor_no { get; set; }

        public int full_day_rate { get; set; }

        public int half_day_rate { get; set; }

        [StringLength(1000)]
        public string hall_description { get; set; }

        public int hallStatusId { get; set; }

        public DateTime? createdTime { get; set; }

        public DateTime? modifiedTime { get; set; }

        public int? display_order { get; set; }

        public virtual tbl_mst_hallStatus tbl_mst_hallStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_trx_booking_timeSlot> tbl_trx_booking_timeSlot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_trx_reservation> tbl_trx_reservation { get; set; }
    }
}
