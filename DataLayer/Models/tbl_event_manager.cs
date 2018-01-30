namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_event_manager
    {
        [Key]
        public long event_managerId { get; set; }

        public long reservationId { get; set; }

        [Required]
        [StringLength(200)]
        public string event_manager_name { get; set; }

        [Required]
        [StringLength(200)]
        public string emailId { get; set; }

        [StringLength(20)]
        public string mobile_no { get; set; }

        public bool? is_active { get; set; }

        public DateTime? createdtime { get; set; }

        public virtual tbl_trx_reservation tbl_trx_reservation { get; set; }
    }
}
