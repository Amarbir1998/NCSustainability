﻿using Microsoft.EntityFrameworkCore;
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
                if (!context.Promotions.Any())
                {
                    context.Promotions.AddRange(
                        new Promotion
                        {
                            Description = "Planting trees in Spring break",
                            SPdate = DateTime.Parse("2020-05-01"),
                            EPdate = DateTime.Parse("2020-09-29")
                        },
                        new Promotion
                        {
                            Description = "Using organic Fertilization in Spring break",
                            SPdate = DateTime.Parse("2020-05-01"),
                            EPdate = DateTime.Parse("2020-09-29")
                        });
                    context.SaveChanges();
                }
                if (!context.Events.Any())
                {
                    context.Events.AddRange(
                        new Event
                        {
                            Title = "Planting Trees Event",
                            Edate = DateTime.Parse("2020-02-21"),
                            EventDescription = "Join NC for this hands-on workshop taught by Stefan Weber, an experienced grower and educator.",
                            EventCategoryID = context.FunFact.FirstOrDefault(cd => cd.EventCategoryName == "Academic").ID

                        },
                        new Event
                        {
                            Title = "Donations",
                            Edate = DateTime.Parse("2020-04-05"),
                            EventDescription = "Donating winter clothes to needy people",
                            EventCategoryID = context.FunFact.FirstOrDefault(cd => cd.EventCategoryName == "Academic").ID
                        },
                        new Event
                        {
                            Title = "Protect The Nature",
                            Edate = DateTime.Parse("2020-04-13"),
                            EventDescription = "What are organic-based fertilizers?" +
"The broad category of organic - based fertilizers includes diverse formulations of products that provide plants with nutrients and / or improve organic matter in the soil.They are applied to plants and / or soils to improve soil fertility," ,
                            EventCategoryID = context.FunFact.FirstOrDefault(cd => cd.EventCategoryName == "Food").ID
                        },
                        new Event
                        {
                            Title = "Plastic Free Environment",
                            Edate = DateTime.Parse("2020-05-12"),
                            EventDescription = "Encouraging people for using their own mugs for coffee / Tea",
                            EventCategoryID = context.FunFact.FirstOrDefault(cd => cd.EventCategoryName == "Waste Management").ID
                        }) ;
                    context.SaveChanges();
                }
                if (!context.subscribers.Any())
                {
                    context.subscribers.AddRange(
                        new Subscriber
                        {
                            Name = "Karanvir",
                            Email = "singhkaranvir72@gmail.com",
                            Phone = "3657788183"
                        },
                        new Subscriber
                        {
                            Name = "Faiyaz",
                            Email = "mkagzi21@gmail.com",
                            Phone = "4372238416"
                        },
                        new Subscriber
                        {
                            Name = "Mit",
                            Email = "shahmit2015@gmail.com",
                            Phone = "6476748647"
                        },
                        new Subscriber
                        {
                            Name = "Amarbir",
                            Email = "asingh457@ncstudents.niagaracollege.ca",
                            Phone = "3433339985"
                        });
                    context.SaveChanges();
                }
                if (!context.EventSubscribers.Any())
                {
                    context.EventSubscribers.AddRange(
                        new EventSubscriber
                        {
                            EventCategoryID = context.FunFact.FirstOrDefault(c => c.EventCategoryName == "Academic").ID,
                            SubscriberID = context.subscribers.FirstOrDefault(p => p.Name == "Mit").ID
                        },
                        new EventSubscriber
                        {
                            EventCategoryID = context.FunFact.FirstOrDefault(c => c.EventCategoryName == "Food").ID,
                            SubscriberID = context.subscribers.FirstOrDefault(p => p.Name == "Mit").ID
                        },
                        new EventSubscriber
                        {
                            EventCategoryID = context.FunFact.FirstOrDefault(c => c.EventCategoryName == "Academic").ID,
                            SubscriberID = context.subscribers.FirstOrDefault(p => p.Name == "Amarbir").ID
                        });
                    context.SaveChanges();
                }

                if (!context.FunFacts.Any())
                {
                    context.FunFacts.AddRange(
                        new FunFact
                        {
                            Title = "Collected the Bio-degradable waste",
                            Email = "fertilizer@ncstudents.niagaracollege.ca",
                            FunFactDescription = "I collected the waste from whole month..."
                        },
                        new FunFact
                        {
                            Title = "Planted trees",
                            Email = "trees@ncstudents.niagaracollege.ca",
                            FunFactDescription = "dfsnk lvaadnj ie wvu oi iydf iweu rugiowerng ieuorn  g"
                        });
                    context.SaveChanges();
                }
                if (!context.LikedFunfacts.Any())
                {
                    context.LikedFunfacts.AddRange(
                        new LikedFunfact
                        {
                            LName = "Amarbir",
                            Email = "asingh457@ncstudents.niagaracollege.ca",
                            FunfactID = context.FunFacts.FirstOrDefault(cd => cd.Title == "Collected the Bio-degradable waste").ID
                        },
                        new LikedFunfact
                        {
                            LName = "karanvir",
                            Email = "ksingh238@ncstudents.niagaracollege.ca",
                            FunfactID = context.FunFacts.FirstOrDefault(cd => cd.Title == "Collected the Bio-degradable waste").ID
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
