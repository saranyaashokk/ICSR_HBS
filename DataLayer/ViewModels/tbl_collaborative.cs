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
    
    public partial class tbl_collaborative
    {
        public long collaborativeId { get; set; }
        public long reservationId { get; set; }
        public string collaborative_faculty { get; set; }
        public long deptId { get; set; }
        public Nullable<long> designationId { get; set; }
        public string tele_no { get; set; }
        public string emailId { get; set; }
        public string mobile_no { get; set; }
        public Nullable<bool> is_active { get; set; }
        public Nullable<System.DateTime> createdtime { get; set; }
    
        public virtual tbl_mst_dept_IIT tbl_mst_dept_IIT { get; set; }
        public virtual tbl_mst_designation_IIT tbl_mst_designation_IIT { get; set; }
        public virtual tbl_trx_reservation tbl_trx_reservation { get; set; }
    }
}