namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_booking_users
    {
        [Key]
        public long booking_userID { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public long deptId { get; set; }

        [StringLength(20)]
        public string mobile_no { get; set; }

        [Required]
        [StringLength(4)]
        public string tele_no { get; set; }

        [Required]
        [StringLength(200)]
        public string emailId { get; set; }

        public bool? is_active { get; set; }

        public DateTime? createdtime { get; set; }

        public virtual tbl_mst_dept_IIT tbl_mst_dept_IIT { get; set; }
    }
}
