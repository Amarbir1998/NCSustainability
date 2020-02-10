using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Sustainability.Models
{
    public class Subscriber
    {
        public int ID { get; set; }
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }

    }
}
