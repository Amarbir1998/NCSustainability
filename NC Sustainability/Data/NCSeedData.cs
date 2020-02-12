using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NCSustainability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Data
{
    public class NCSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NCDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<NCDbContext>>()))
            {
                if (!context.EventCategories.Any())
                {
                    context.EventCategories.AddRange(
                        new EventCategory
                        {
                            EventCategoryName = "Academic"
                        },
                        new EventCategory
                        {
                            EventCategoryName = "Food"
                        },
                        new EventCategory
                        {
                            EventCategoryName = "Waste Management"
                        });
                    context.SaveChanges();
                }
                if (!context.Events.Any())
                {
                    context.Events.AddRange(
                        new Event
                        {
                            Title = "Sample",
                            Edate = DateTime.Parse("2020-01-30"),
                            EventDescription = "Growing plants nearby places in town",
                            EventCategoryID = context.EventCategories.FirstOrDefault(cd => cd.EventCategoryName == "Academic").ID

                        },
                        new Event
                        {
                            Title = "D",
                            Edate = DateTime.Parse("2020-02-05"),
                            EventDescription = "Donating winter clothes to needy people",
                            EventCategoryID = context.EventCategories.FirstOrDefault(cd => cd.EventCategoryName == "Academic").ID
                        },
                        new Event
                        {
                            Title = "WM",
                            Edate = DateTime.Parse("2020-02-07"),
                            EventDescription = "Collecting waste which can be used for fertilisers",
                            EventCategoryID = context.EventCategories.FirstOrDefault(cd => cd.EventCategoryName == "Food").ID
                        },
                        new Event
                        {
                            Title = "BY",
                            Edate = DateTime.Parse("2020-02-12"),
                            EventDescription = "Encouraging people for using their own mugs for coffee / Tea",
                            EventCategoryID = context.EventCategories.FirstOrDefault(cd => cd.EventCategoryName == "Waste Management").ID
                        });
                    context.SaveChanges();
                }
                if (!context.subscribers.Any())
                {
                    context.subscribers.AddRange(
                        new Subscriber
                        {
                            Name = "Karanvir",
                            Email = "singhkaranvir72@gmail.com"
                        },
                        new Subscriber
                        {
                            Name = "Faiyaz",
                            Email = "mkagzi21@gmail.com"
                        },
                        new Subscriber
                        {
                            Name = "Mit",
                            Email = "shahmit2015@gmail.com"
                        },
                        new Subscriber
                        {
                            Name = "Amarbir",
                            Email = "asingh457@ncstudents.niagaracollege.ca"
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
