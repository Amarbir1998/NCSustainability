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
        [RegularExpression(@"^([\w]*[\w\.]*(?!\.)@ncstudents.niagaracollege.ca)", ErrorMessage = "Email address should end with 'niagaracollege.ca'")]
        [Required(ErrorMessage = "Please enter email address.")]
        public string Email { get; set; }

        [Display(Name = "Context Description")]
        [Required(ErrorMessage = "Context Description is required.")]
        public string FunFactDescription { get; set; }

        //[ScaffoldColumn(false)]
        //public byte[] imageContent { get; set; }

        //[StringLength(256)]
        //[ScaffoldColumn(false)]
        //public string imageMimeType { get; set; }

        //[StringLength(100, ErrorMessage = "The name of the file cannot be more than 100 characters.")]
        //[Display(Name = "File Name")]
        //[ScaffoldColumn(false)]
        //public string imageFileName { get; set; }

        public virtual ICollection<LikedFunfact> LikedFunfacts { get; set; }

    }
}
