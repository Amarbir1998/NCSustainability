using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NCSustainability.Models
{
    public class EventCategory
    {
        public EventCategory()
        {
            this.Events = new HashSet<Event>();
        }

        public int ID { get; set; }

        [Display(Name = "Category Name")]
        public string EventCategoryName { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
