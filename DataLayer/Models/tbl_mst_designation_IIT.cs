namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_mst_designation_IIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_mst_designation_IIT()
        {
            tbl_collaborative = new HashSet<tbl_collaborative>();
            tbl_faculty_IIT = new HashSet<tbl_faculty_IIT>();
        }

        [Key]
        public long designationId { get; set; }

        [Required]
        [StringLength(50)]
        public string designation { get; set; }

        [StringLength(10)]
        public string designation_code { get; set; }

        public bool? is_active { get; set; }

        public DateTime? createdTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_collaborative> tbl_collaborative { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_faculty_IIT> tbl_faculty_IIT { get; set; }
    }
}
