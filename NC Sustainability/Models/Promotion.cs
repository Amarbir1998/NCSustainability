using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Models
{
    public class Promotion
    {
        public Promotion()
        {
        }
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

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your name.")]
        public string Description { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is required.")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime SPdate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is required.")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EPdate { get; set; }
    }
}
