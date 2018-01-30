namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_mst_mode_of_payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_mst_mode_of_payment()
        {
            tbl_payment = new HashSet<tbl_payment>();
        }

        [Key]
        public int mode_of_paymentId { get; set; }

        [Required]
        [StringLength(50)]
        public string mode_of_payment { get; set; }

        public DateTime? createdTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_payment> tbl_payment { get; set; }
    }
}
