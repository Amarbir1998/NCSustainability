using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Models
{
    public class EventSubscriber
    {
        public int EventCategoryID { get; set; }
        public EventCategory EventCategory { get; set; }

        public int SubscriberID { get; set; }
        public Subscriber Subscriber { get; set; }
    }
}
