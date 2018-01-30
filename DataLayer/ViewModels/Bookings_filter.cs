using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels
{
    public class Bookings_filter
    {      
        [Display(Name = "Event Start Date")]
        public DateTime? start_date { get; set; }
        
        [Display(Name = "Event End Date")]
        public DateTime? end_date { get; set; }
    }
}
