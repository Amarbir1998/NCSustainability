using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Sustainability.Models
{
    public class EmailNotifyViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "To (Email Address)")]
        public string ToEmail { get; set; }
    }
}
