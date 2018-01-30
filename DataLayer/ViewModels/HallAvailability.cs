using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataLayer.ViewModels
{
    public class HallAvailability
    {
        [Key]
        public int hallId { get; set; }

        [StringLength(100)]
        public string hallName { get; set; }

        public DateTime start_time { get; set; }

        public DateTime end_time { get; set; }
    }
}