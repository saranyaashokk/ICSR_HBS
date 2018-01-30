namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_mst_hallStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_mst_hallStatus()
        {
            tbl_dining_halls = new HashSet<tbl_dining_halls>();
            tbl_halls = new HashSet<tbl_halls>();
        }

        [Key]
        public int hallStausId { get; set; }

        [Required]
        [StringLength(50)]
        public string hallStatus { get; set; }

        public DateTime? createdTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_dining_halls> tbl_dining_halls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_halls> tbl_halls { get; set; }
    }
}
