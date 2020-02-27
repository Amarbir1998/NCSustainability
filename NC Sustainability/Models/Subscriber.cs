using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Models
{
    public class Subscriber
    {
        public int ID { get; set; }
        [Display(Name ="Name")]
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [RegularExpression(@"^([\w]*[\w\.]*(?!\.)@ncstudents.niagaracollege.ca)", ErrorMessage ="Email address should end with 'niagaracollege.ca'")]
        [Required(ErrorMessage = "Please enter email address.")]
        public string Email { get; set; }

        [Display(Name = "Event Categories")]
        public ICollection<EventSubscriber> EventSubscribers { get; set; }
    }
}
