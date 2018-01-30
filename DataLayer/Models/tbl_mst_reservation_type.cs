namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_mst_reservation_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_mst_reservation_type()
        {
            tbl_trx_reservation = new HashSet<tbl_trx_reservation>();
        }

        [Key]
        public int res_typeId { get; set; }

        [Required]
        [StringLength(100)]
        public string res_type { get; set; }

        public bool? is_payment { get; set; }

        public DateTime? createdTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_trx_reservation> tbl_trx_reservation { get; set; }
    }
}
