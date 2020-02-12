using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Models
{
    public class Event
    {
        public Event()
        {
            //ToAddresses = new List<Subscriber>();
            //FromAddresses = new List<Subscriber>();
        }

        public int ID { get; set; }
        [Display(Name ="Title")]
        [Required(ErrorMessage = "Event title is required.")]
        public string Title { get; set; }

        [Display(Name = "Event Date")]
        [Required(ErrorMessage = "Event Date is required.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Edate { get; set; }

        [Display(Name = "Event Description")]
        [Required(ErrorMessage = "Event Description is required.")]
        public string EventDescription { get; set; }

        [ScaffoldColumn(false)]
        public byte[] imageContent { get; set; }

        [StringLength(256)]
        [ScaffoldColumn(false)]
        public string imageMimeType { get; set; }

        [StringLength(100, ErrorMessage = "The name of the file cannot be more than 100 characters.")]
        [Display(Name = "File Name")]
        [ScaffoldColumn(false)]
        public string imageFileName { get; set; }


        [Display(Name = "Event Category")]
        [Required(ErrorMessage = "Event Category is required.")]
        public int EventCategoryID { get; set; }

        [Display(Name = "Event Category")]
        public virtual EventCategory EventCategory { get; set; }

        //public List<Subscriber> ToAddresses { get; set; }
        //public List<Subscriber> FromAddresses { get; set; }
    }
}
