namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_users_ICSR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_users_ICSR()
        {
            tbl_trx_reservation = new HashSet<tbl_trx_reservation>();
        }

        [Key]
        public long userId { get; set; }

        [Required]
        [StringLength(200)]
        public string full_name { get; set; }

        [Required]
        [StringLength(100)]
        public string designation { get; set; }

        [Required]
        [StringLength(100)]
        public string userName { get; set; }

        [Required]
        [StringLength(100)]
        public string passWord { get; set; }

        public bool? is_approver { get; set; }

        public bool? is_active { get; set; }

        public DateTime? createdtime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_trx_reservation> tbl_trx_reservation { get; set; }
    }
}
