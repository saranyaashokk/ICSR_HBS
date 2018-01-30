namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_receipt
    {
        [Key]
        public long receiptId { get; set; }

        public long paymentId { get; set; }

        public DateTime receipt_date { get; set; }

        public DateTime? createdTime { get; set; }

        public virtual tbl_payment tbl_payment { get; set; }
    }
}
