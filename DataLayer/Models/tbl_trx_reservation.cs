namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_trx_reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_trx_reservation()
        {
            tbl_collaborative = new HashSet<tbl_collaborative>();
            tbl_event_manager = new HashSet<tbl_event_manager>();
            tbl_faculty_IIT = new HashSet<tbl_faculty_IIT>();
            tbl_payment = new HashSet<tbl_payment>();
            tbl_trx_booking_timeSlot = new HashSet<tbl_trx_booking_timeSlot>();
            tbl_trx_email_log = new HashSet<tbl_trx_email_log>();
        }

        [Key]
        public long reservationId { get; set; }

        public int hallId { get; set; }

        public int? d_hallId { get; set; }

        public int res_typeId { get; set; }

        [Required]
        [StringLength(500)]
        public string programme_title { get; set; }

        public bool? is_collaborative { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

        public bool? is_with_dining { get; set; }

        public int approval_statusId { get; set; }

        public long? approvedBy { get; set; }

        public DateTime? ApprovedTime { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? reservation_amount { get; set; }

        public bool? is_paid { get; set; }

        public DateTime? createdTime { get; set; }

        public TimeSpan start_time { get; set; }

        public TimeSpan end_time { get; set; }

        public bool is_fullDay { get; set; }

        public bool? is_active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_collaborative> tbl_collaborative { get; set; }

        public virtual tbl_dining_halls tbl_dining_halls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_event_manager> tbl_event_manager { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_faculty_IIT> tbl_faculty_IIT { get; set; }

        public virtual tbl_halls tbl_halls { get; set; }

        public virtual tbl_mst_approval_status tbl_mst_approval_status { get; set; }

        public virtual tbl_mst_reservation_type tbl_mst_reservation_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_payment> tbl_payment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_trx_booking_timeSlot> tbl_trx_booking_timeSlot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_trx_email_log> tbl_trx_email_log { get; set; }

        public virtual tbl_users_ICSR tbl_users_ICSR { get; set; }

        public virtual tbl_trx_reservation tbl_trx_reservation1 { get; set; }

        public virtual tbl_trx_reservation tbl_trx_reservation2 { get; set; }
    }
}
