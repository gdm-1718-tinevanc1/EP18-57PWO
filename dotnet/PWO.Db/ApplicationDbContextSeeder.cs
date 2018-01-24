using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OpenIddict;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PWO.Models;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using OpenIddict;
// using Npgsql.EntityFrameworkCore.PostgreSQL;
// using PWO.Models.Security;

namespace PWO.Db
{
    public class ApplicationDbContextSeeder
    {
       public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetService<ApplicationDbContext>())
            {
                var random = new Random();
                var lorem = new Bogus.DataSets.Lorem(locale: "nl");

                if(!context.Financingforms.Any())
                {
                  context.Financingforms.AddRange(new List<Financingform>()
                    {
                      new Financingform { Name = "PWO"},
                      new Financingform { Name = "Extern"}
                    });
                  await context.SaveChangesAsync();
                }


                if(!context.Links.Any())
                {
                  context.Links.AddRange(new List<Link>()
                    {
                      new Link { Name = "Project", Description = "test", TypeLink = TypeLink.Project},
                      new Link { Name = "Url", Description = "test", TypeLink = TypeLink.Url}
                    });
                  await context.SaveChangesAsync();
                }

                if(!context.Mediums.Any())
                {
                  context.Mediums.AddRange(new List<Media>()
                    {
                      new Media { Url = "Url", TypeMedia = TypeMedia.Icon},
                      new Media { Url = "Url2", TypeMedia = TypeMedia.PrimaryImage}
                    });
                  await context.SaveChangesAsync();
                }


                if(!context.Participants.Any())
                {
                  context.Participants.AddRange(new List<Participant>()
                    {
                      new Participant { Name = "Test", TypeParticipant = TypeParticipant.ODC},
                      new Participant { Name = "Test2", TypeParticipant = TypeParticipant.Projectmedewerker},
                      new Participant { Name = "Test3", TypeParticipant = TypeParticipant.Opleiding}
                    });
                  await context.SaveChangesAsync();
                }

                if(!context.Publications.Any())
                {
                  context.Publications.AddRange(new List<Publication>()
                    {
                      new Publication { Name = "Test"},
                      new Publication { Name = "Test2"}
                    });
                  await context.SaveChangesAsync();
                }

                if(!context.States.Any())
                {
                  context.States.AddRange(new List<Status>()
                    {
                      new Status { Name = "Test", Description = "Test description"},
                      new Status { Name = "Test2", Description = "Test2 description"}
                    });
                  await context.SaveChangesAsync();
                }

                if(!context.Spearheads.Any())
                {
                  context.Spearheads.AddRange(new List<Spearhead>()
                    {
                      new Spearhead { Name = "ondernemingschap", Description = "ondernemerschap, organisatie en competenties"},
                      new Spearhead { Name = "zorg", Description = "zorg, welzijn en zelfredzaamheid"}
                    });
                  await context.SaveChangesAsync();
                }

                if(!context.Tags.Any())
                {
                  context.Tags.AddRange(new List<Tag>()
                    {
                      new Tag { Name = "Projectmedewerker", Description = "description 1"},
                      new Tag { Name = "1e graad onderwijs", Description = "description 2"}
                    });
                  await context.SaveChangesAsync();
                }


                if(!context.Profiles.Any()) 
                {
                    var profileSkeleton = new Faker<PWO.Models.Profile>()
                        .RuleFor(c => c.LastName, f => f.Name.LastName())
                        .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                        .RuleFor(c => c.UserName, (f, c) => f.Internet.UserName(c.FirstName, c.LastName))
                        .RuleFor(c => c.Email, f => f.Internet.Email())
                        .RuleFor(c => c.Employeenumber, f => f.Random.Number(500, 2000))
                        .FinishWith((f, u) =>
                        {
                            Console.WriteLine("Profiles created with Bogus: {0}!", u.Id);
                        });
                   
                    var profiles = new List<Profile>();

                    for(var i = 0; i < 50; i++)
                    {
                        var profile = profileSkeleton.Generate();

                        profiles.Add(profile);
                    }

                    context.Profiles.AddRange(profiles);
                    await context.SaveChangesAsync();
                }


                if(!context.Projects.Any()) 
                {
                    var projectSkeleton = new Faker<PWO.Models.Project>()
                        .RuleFor(c => c.Startdate, f => f.Date.Soon())
                        .RuleFor(c => c.Enddate, f => f.Date.Future())
                        .RuleFor(c => c.Title, f => lorem.Sentence())
                        .RuleFor(c => c.Subtitle, f => lorem.Sentence())
                        .RuleFor(c => c.Description, f => lorem.Sentence(3))
                        .RuleFor(c => c.Abstract, f => lorem.Paragraphs(random.Next(1, 3)))
                        .FinishWith((f, u) =>
                        {
                            Console.WriteLine("Projects created with Bogus: {0}!", u.Id);
                        });
                   
                    var projects = new List<Project>();
                    var mediums = context.Mediums.ToList();
                    var financingforms = context.Financingforms.ToList();

                    for(var i = 0; i < 50; i++)
                    {
                        var project = projectSkeleton.Generate();
                        project.MediaId = mediums[random.Next(mediums.Count - 1)].Id;
                        project.FinancingformId = financingforms[random.Next(financingforms.Count - 1)].Id;

                        context.Projects.Add(project);
                    }

                    context.Projects.AddRange(projects);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
