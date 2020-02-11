using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Models
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddresses = new List<Subscriber>();
            FromAddresses = new List<Subscriber>();
        }
        [Display(Name ="To:")]
        public List<Subscriber> ToAddresses { get; set; }
        [Display(Name = "From:")]
        public List<Subscriber> FromAddresses { get; set; }
        [Display(Name = "Subject:")]
        public string Subject { get; set; }
        [Display(Name = "Content:")]
        public string Content { get; set; }
    }
}
