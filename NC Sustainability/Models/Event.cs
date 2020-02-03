using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Sustainability.Models
{
    public class Event
    {

        public int ID { get; set; }
        public string Title { get; set; }

        public DateTime Edate { get; set; }

        public string EventDescription { get; set; }

        public int EventCategoryID { get; set; }

        public virtual EventCategory EventCategory { get; set; }
    }
}
