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
    
    public partial class tbl_mst_dept_ICSR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_mst_dept_ICSR()
        {
            this.tbl_users_ICSR = new HashSet<tbl_users_ICSR>();
        }
    
        public int deptId { get; set; }
        public string deptName { get; set; }
        public Nullable<bool> is_icsr { get; set; }
        public Nullable<System.DateTime> createdTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_users_ICSR> tbl_users_ICSR { get; set; }
    }
}
