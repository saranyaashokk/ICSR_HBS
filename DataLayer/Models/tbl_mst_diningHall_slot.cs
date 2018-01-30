namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_mst_diningHall_slot
    {
        [Key]
        public long dining_slot_id { get; set; }

        [Required]
        [StringLength(50)]
        public string dining_slot_name { get; set; }

        public TimeSpan from_time { get; set; }

        public TimeSpan to_time { get; set; }

        public bool? is_active { get; set; }
    }
}
