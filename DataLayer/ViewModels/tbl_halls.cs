//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.ViewModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_halls
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_halls()
        {
            this.tbl_trx_reservation = new HashSet<tbl_trx_reservation>();
        }
    
        public int hallId { get; set; }
        public string hallName { get; set; }
        public Nullable<int> hall_capacity { get; set; }
        public int floor_no { get; set; }
        public int full_day_rate { get; set; }
        public int half_day_rate { get; set; }
        public string hall_description { get; set; }
        public int hallStatusId { get; set; }
        public Nullable<System.DateTime> createdTime { get; set; }
        public Nullable<System.DateTime> modifiedTime { get; set; }
        public Nullable<int> display_order { get; set; }
    
        public virtual tbl_mst_hallStatus tbl_mst_hallStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_trx_reservation> tbl_trx_reservation { get; set; }
    }
}