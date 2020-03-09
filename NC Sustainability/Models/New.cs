using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Models
{
    public class New
    {
        public int ID { get; set; }

        [ScaffoldColumn(false)]
        public byte[] imageContent { get; set; }

        [StringLength(256)]
        [ScaffoldColumn(false)]
        public string imageMimeType { get; set; }

        [StringLength(100, ErrorMessage = "The name of the file cannot be more than 100 characters.")]
        [Display(Name = "File Name")]
        [ScaffoldColumn(false)]
        public string imageFileName { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter title.")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter description.")]
        public string Description { get; set; }

        [Display(Name = "Posted Date")]
        [Required(ErrorMessage = "Posted Date is required.")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Pdate { get; set; }
    }
}
