﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Models
{
    public interface IEmailService
    {
        void Send(Event @event);
        List<Event> ReceiveEmail(int maxCount = 10);
    }
}
