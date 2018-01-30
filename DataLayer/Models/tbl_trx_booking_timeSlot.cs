namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_trx_booking_timeSlot
    {
        [Key]
        public long timeSlot_id { get; set; }

        public long reservationId { get; set; }

        public int hallId { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

        public TimeSpan start_time { get; set; }

        public TimeSpan end_time { get; set; }

        public int approval_statusId { get; set; }

        public DateTime? ApprovedTime { get; set; }

        public bool? is_active { get; set; }

        public DateTime? createdtime { get; set; }

        public virtual tbl_halls tbl_halls { get; set; }

        public virtual tbl_mst_approval_status tbl_mst_approval_status { get; set; }

        public virtual tbl_trx_reservation tbl_trx_reservation { get; set; }
    }
}
