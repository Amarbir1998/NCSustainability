using NCSustainability.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Models
{
    public class FunFact
    {
        public FunFact()
        {
            this.LikedFunfacts = new HashSet<LikedFunfact>();
        }

        public int ID { get; set; }

        [Display(Name = "Title of Fun")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }


        [Display(Name = "Email Address")]
        [RegularExpression(@"^([\w]*[\w\.]*(?!\.)@ncstudents.niagaracollege.ca)", ErrorMessage = "Email address should end with 'ncstudents.niagaracollege.ca'")]
        [Required(ErrorMessage = "Please enter email address.")]
        public string Email { get; set; }

        [Display(Name = "Context Description")]
        [Required(ErrorMessage = "Context Description is required.")]
        public string FunFactDescription { get; set; }

        public virtual ICollection<LikedFunfact> LikedFunfacts { get; set; }

    }
}
