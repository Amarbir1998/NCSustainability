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
                            imageFileName = "ProtectTheNature.png",
                           
                            Title = "Protect The Nature",
                            Edate = DateTime.Parse("2020-03-13"),
                            EventDescription = "What are organic-based fertilizers?" +
"The broad category of organic - based fertilizers includes diverse formulations of products that provide plants with nutrients and / or improve organic matter in the soil.They are applied to plants and / or soils to improve soil fertility," +
                            "plant vigour,"
                            + "produce quality and yield.Organic - based fertilizers are used in both organic and conventional agriculture."

+ "Organic - based fertilizers include three specific product categories: organic fertilizers,"
                            + "organo - mineral fertilizers and organic soil improvers.ECOFI defines and differentiates these three linked product categories as follows:"

+ "Organic fertilizer: a fertilizer whose main function is to provide nutrients under organic forms from organic materials of plant and / or animal origin." +
 "Organo - mineral fertilizer: a complex fertilizer obtained by industrial co - formulation of one or more inorganic fertilizers with one or more organic fertilizers and / or organic soil improvers into solid forms(with the exception of dry mixes) or liquids."
+ "Organic soil improver: a soil improver containing carbonaceous materials of plant and / or animal origin,"
                            + "whose main function is to maintain or increase the soil organic matter content.",
                            EventCategoryID = context.EventCategories.FirstOrDefault(cd => cd.EventCategoryName == "Food").ID
                        },
                        new Event
                        {
                            Title = "BY",
                            Edate = DateTime.Parse("2020-02-12"),
                            EventDescription = "Encouraging people for using their own mugs for coffee / Tea",
                            EventCategoryID = context.EventCategories.FirstOrDefault(cd => cd.EventCategoryName == "Waste Management").ID
                        }) ;
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
                if (!context.EventSubscribers.Any())
                {
                    context.EventSubscribers.AddRange(
                        new EventSubscriber
                        {
                            EventCategoryID = context.EventCategories.FirstOrDefault(c => c.EventCategoryName == "Academic").ID,
                            SubscriberID = context.subscribers.FirstOrDefault(p => p.Name == "Mit").ID
                        },
                        new EventSubscriber
                        {
                            EventCategoryID = context.EventCategories.FirstOrDefault(c => c.EventCategoryName == "Food").ID,
                            SubscriberID = context.subscribers.FirstOrDefault(p => p.Name == "Mit").ID
                        },
                        new EventSubscriber
                        {
                            EventCategoryID = context.EventCategories.FirstOrDefault(c => c.EventCategoryName == "Academic").ID,
                            SubscriberID = context.subscribers.FirstOrDefault(p => p.Name == "Amarbir").ID
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
