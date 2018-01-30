using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer.ViewModels
{
    public class Admin_View_booking
    {

        [Key]
        [Display(Name ="Booking ID")]
        public long reservationId { get; set; }
        [Required]
        public int hallId { get; set; }
        [Required]
        [Display(Name ="Hall Name")]
        public string hallName { get; set; }

       public IEnumerable<SelectListItem> halls { get; set; }

        [Required]
        [Display(Name = "Programme title")]
        public string programme_title { get; set; }
       // [Required]
        [Display(Name = "Start")]
        [DisplayFormat(DataFormatString = "{0:dd MMM, yyyy hh:mm tt}")]
        public DateTime? start_date { get; set; }
      //  [Required]
        [Display(Name = "End")]
        [DisplayFormat(DataFormatString = "{0:dd MMM, yyyy hh:mm tt}")]
        public DateTime? end_date { get; set; }
        [Required]
        [Display(Name = "Faculty")]
        public string facultyName { get; set; }
        [Required]
        [Display(Name = "Event Manager")]
        public string event_manager_name { get; set; }
        [Display(Name ="Collaborative faculty")]
        public string collaborative_faculty { get; set; }
        [Required]
        public int approval_statusId { get; set; }
        [Required]
        [Display(Name ="Approval Status")]
        public string approval_status { get; set; }
    }
}
