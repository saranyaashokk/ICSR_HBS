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
    
    public partial class tbl_mst_designation_IIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_mst_designation_IIT()
        {
            this.tbl_collaborative = new HashSet<tbl_collaborative>();
            this.tbl_faculty_IIT = new HashSet<tbl_faculty_IIT>();
        }
    
        public long designationId { get; set; }
        public string designation { get; set; }
        public string designation_code { get; set; }
        public Nullable<bool> is_active { get; set; }
        public Nullable<System.DateTime> createdTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_collaborative> tbl_collaborative { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_faculty_IIT> tbl_faculty_IIT { get; set; }
    }
}
