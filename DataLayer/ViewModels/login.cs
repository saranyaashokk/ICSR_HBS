using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels
{
    public class login
    {
        [Key]
        public long userId { get; set; }

        [Required]
        [StringLength(200)]
        public string full_name { get; set; }

        [Required]
        [StringLength(100)]
        public string designation { get; set; }

        [Required]
        [StringLength(100)]
        public string userName { get; set; }

        [Required]
        [StringLength(100)]
        public string passWord { get; set; }

        public bool? is_approver { get; set; }

        public bool? is_active { get; set; }
    }
}
