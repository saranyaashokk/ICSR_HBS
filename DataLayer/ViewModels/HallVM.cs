using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataLayer.ViewModels
{
    public class HallVM
    {
        [Key]
        [Display(Name =" hall ")]
        [Required(ErrorMessage = "select hall !")]
        public int hallId { get; set; }


        [StringLength(100)]
        public string hallName { get; set; }

        public IEnumerable<SelectListItem> halls { get; set; }

        [Required]
        [Display(Name = "Event Start Date")]
        public DateTime? start_date { get; set; }

        [Required]
        [Display(Name = "Event End Date")]
        public DateTime? end_date { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public string start_time { get; set; }


        [Required]
        [Display(Name = "End Time")]
        public string end_time { get; set; }

        [Required]
        [Display(Name = "Is Full Day")]
        public bool is_fullDay { get; set; }

        public decimal? reservation_amount { get; set; }

        //Display Formats

        public string Event_Time
        {
            get
            {
                return start_time + " " + "To" + " " + end_time;
            }
        }

        public string sFullDay
        {
            get
            {
                if (is_fullDay == true)
                    return "Yes";
                else
                    return "No";
            }
        }

        public string StartDate_trim
        {
            get
            {
                return start_date.ToString().Substring(0, 10);
            }
        }

        public string EndDate_trim
        {
            get
            {
                return end_date.ToString().Substring(0, 10);
            }
        }
        
        [Display(Name = " Reservation type ")]
        [Required(ErrorMessage = "*")]
        public int? res_typeId { get; set; }

        public string res_type { get; set; }

        public bool? is_payment { get; set; }

        public IEnumerable<SelectListItem> resTypeOptions { get; set; }
                
        public int d_hallId { get; set; }
               
        [StringLength(100)]
        public string d_hallName { get; set; }

        public IEnumerable<SelectListItem> d_halls { get; set; }


        
        public int dining_slot_id { get; set; }

        [StringLength(100)]
        public string dining_slot_name { get; set; }

        public IEnumerable<SelectListItem> d_slots { get; set; }


        [Required(ErrorMessage = "*")]
        [StringLength(500)]
        public string programme_title { get; set; }


        public bool is_with_dining { get; set; }

        //Faculty Details

        [Required(ErrorMessage = "*")]
        [StringLength(200)]
        public string facultyName { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(1000, 9999, ErrorMessage = "*")]
        public string fac_tele_no { get; set; }

        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "*")]
        public string fac_emailId { get; set; }

        [Required(ErrorMessage = "*")]
        
        [Range(1000000000, 9999999999,ErrorMessage = "*")]
        public string fac_mobile_no { get; set; }

        //department faculty
        [Required(ErrorMessage = "*")]
        public int dd_fac_deptId { get; set; }

        
        [StringLength(50)]
        public string dd_deptName { get; set; }

        public IEnumerable<SelectListItem> dd_deps { get; set; }              


        //Event Manager Details

        [Required(ErrorMessage = "*")]
        [StringLength(200)]
        public string event_manager_name { get; set; }

        [Required(ErrorMessage = "*" )]
        [EmailAddress(ErrorMessage = "*")]
        public string EM_emailId { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(1000000000, 9999999999, ErrorMessage = "*")]
        public string EM_mobile_no { get; set; }


        //Collaborative Faculty Details

        //[Required(ErrorMessage = "*")]
       // [StringLength(200)]
        public string collaborative_faculty { get; set; }

       // [Required(ErrorMessage = "*")]
        //[StringLength(4)]
        public string CFac_tele_no { get; set; }

       // [Required(ErrorMessage = "*")]
       // [StringLength(200)]
        public string CFac_emailId { get; set; }

        // [Required(ErrorMessage = "*")]        
        //[MaxLength(10)]
        public string CFac_mobile_no { get; set; }


        //department faculty
        //[RequiredIf("UserType", "Vendor", ErrorMessage = "Please Select City")]
        public int? dd_cfac_deptId { get; set; }

        
        [StringLength(50)]
        public string dd_cfac_deptName { get; set; }

        public IEnumerable<SelectListItem> dd_cfac_deps { get; set; }

        public bool is_collaborative { get; set; }
    } 
}