using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels
{
    public class reservationInfo
    {
        [Key]
        public long reservationId { get; set; }

        [Display(Name = " Reservation Type ")]
        public string res_type { get; set; }

        [Display(Name = " Faculty ")]
        public string facultyName { get; set; }

        public string fac_tele_no { get; set; }

        public string fac_emailId { get; set; }
        
        public string fac_mobile_no { get; set; }

        public string dd_deptName { get; set; }

        [Display(Name = " Reservation Amount ")]
        public decimal? reservation_amount { get; set; }
        //Event Manager Details

        [Display(Name = " EventManager ")]
        public string event_manager_name { get; set; }

        public string EM_emailId { get; set; }


        public string EM_mobile_no { get; set; }


        //Collaborative Faculty Details

        [Display(Name = " Collaborative Faculty ")]
        public string collaborative_faculty { get; set; }

        public string CFac_tele_no { get; set; }
        
        public string CFac_emailId { get; set; }

        public string CFac_mobile_no { get; set; }
    }
}
