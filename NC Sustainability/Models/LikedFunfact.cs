using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Models
{
    public class LikedFunfact
    {
        public LikedFunfact()
        {
        }

        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Title is required")]
        public string LName { get; set; }


        [Display(Name = "Email Address")]
        [RegularExpression(@"^([\w]*[\w\.]*(?!\.)@ncstudents.niagaracollege.ca)", ErrorMessage = "Email address should end with 'niagaracollege.ca'")]
        [Required(ErrorMessage = "Please enter email address.")]
        public string Email { get; set; }


        [Display(Name = "Fun Facts Liked")]
        [Required(ErrorMessage = "Fun Facts is required.")]
        public int FunfactID { get; set; }

        [Display(Name = "Fun Facts Liked")]
        public virtual FunFact FunFact { get; set; }
    }
}
