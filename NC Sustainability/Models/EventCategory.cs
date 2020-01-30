using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Sustainability.Models
{
    public class EventCategory
    {
        public EventCategory()
        {
            this.Events = new HashSet<Event>();
        }

        public int ID { get; set; }
        public string EventCategoryName { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
