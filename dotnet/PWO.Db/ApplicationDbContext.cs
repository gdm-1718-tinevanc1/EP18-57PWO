using System;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using OpenIddict;
// using Npgsql.EntityFrameworkCore.PostgreSQL;
using PWO.Models;
using PWO.Models.Security;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OpenIddict;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PWO.Db
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        
        public DbSet<Project> Projects { get; set; }
        public DbSet<Financingform> Financingforms { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Media> Mediums { get; set; }
        public DbSet<Status> States { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Spearhead> Spearheads { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProjectProfile> ProjectProfiles { get; set; }

        public DbSet<ProjectLink> ProjectLinks { get; set; }
        public DbSet<ProjectTag> ProjectTags { get; set; }
        public DbSet<ProjectParticipant> ProjectParticipants { get; set; }
        public DbSet<ProjectPublication> ProjectPublications { get; set; }
        public DbSet<ProjectSpearhead> ProjectSpearheads { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // project
            builder.Entity<Project>()
              .HasKey(p => p.Id);

            builder.Entity<Project>()
              .Property(p => p.Startdate)
              .IsRequired();

            builder.Entity<Project>()
              .Property(p => p.Enddate)
              .IsRequired();

            builder.Entity<Project>()
              .Property(p => p.Title)
              .HasMaxLength(255)
              .IsRequired();

            builder.Entity<Project>()
              .Property(p => p.Subtitle)
              .HasMaxLength(300)
              .IsRequired();

            builder.Entity<Project>()
              .Property(p => p.Description)
              .HasMaxLength(500)
              .IsRequired();

            builder.Entity<Project>()
              .Property(p => p.Abstract)
              .HasMaxLength(5000)
              .IsRequired();

            builder.Entity<Project>()
                .HasOne(l => l.Media)
                .WithMany(l => l.Projects)
                .HasForeignKey(l => l.MediaId);

            builder.Entity<Project>()
                .HasOne(l => l.Financingform)
                .WithMany(l => l.Projects)
                .HasForeignKey(l => l.FinancingformId);

            //
            builder.Entity<ProjectParticipant>()
                .HasKey(a => new { a.ProjectId, a.ParticipantId });

            builder.Entity<ProjectParticipant>()
                .HasOne(da => da.Project)
                .WithMany(d => d.Participants)
                .HasForeignKey(da => da.ProjectId);
                
            builder.Entity<ProjectParticipant>()
                .HasOne(da => da.Participant)
                .WithMany(d => d.Projects)
                .HasForeignKey(da => da.ParticipantId);

            
            //
            builder.Entity<ProjectLink>()
                .HasKey(a => new { a.ProjectId, a.LinkId });

            builder.Entity<ProjectLink>()
                .HasOne(da => da.Project)
                .WithMany(d => d.Links)
                .HasForeignKey(da => da.ProjectId);
                
            builder.Entity<ProjectLink>()
                .HasOne(da => da.Link)
                .WithMany(d => d.Projects)
                .HasForeignKey(da => da.LinkId);

            
            //
            builder.Entity<ProjectSpearhead>()
                .HasKey(a => new { a.ProjectId, a.SpearheadId });

            builder.Entity<ProjectSpearhead>()
                .HasOne(da => da.Project)
                .WithMany(d => d.Spearheads)
                .HasForeignKey(da => da.ProjectId);
                
            builder.Entity<ProjectSpearhead>()
                .HasOne(da => da.Spearhead)
                .WithMany(d => d.Projects)
                .HasForeignKey(da => da.SpearheadId);


            //
            builder.Entity<ProjectTag>()
                .HasKey(a => new { a.ProjectId, a.TagId });

            builder.Entity<ProjectTag>()
                .HasOne(da => da.Project)
                .WithMany(d => d.Tags)
                .HasForeignKey(da => da.ProjectId);
                
            builder.Entity<ProjectTag>()
                .HasOne(da => da.Tag)
                .WithMany(d => d.Projects)
                .HasForeignKey(da => da.TagId);


            // 
            builder.Entity<ProjectPublication>()
                .HasKey(a => new { a.ProjectId, a.PublicationId });

            builder.Entity<ProjectPublication>()
                .HasOne(da => da.Project)
                .WithMany(d => d.Publications)
                .HasForeignKey(da => da.ProjectId);
                
            builder.Entity<ProjectPublication>()
                .HasOne(da => da.Publication)
                .WithMany(d => d.Projects)
                .HasForeignKey(da => da.PublicationId);

            
            // 
            builder.Entity<ProjectProfile>()
                .HasKey(a => new { a.ProjectId, a.ProfileId });

            builder.Entity<ProjectProfile>()
                .HasOne(da => da.Project)
                .WithMany(d => d.Profiles)
                .HasForeignKey(da => da.ProjectId);
                
            builder.Entity<ProjectProfile>()
                .HasOne(da => da.Profile)
                .WithMany(d => d.Projects)
                .HasForeignKey(da => da.ProfileId);



            // financingform
            builder.Entity<Financingform>()
              .HasKey(f => f.Id);

            builder.Entity<Financingform>()
              .Property(f => f.Name)
              .HasMaxLength(255)
              .IsRequired();

              // link
            builder.Entity<Link>()
              .HasKey(l => l.Id);

            builder.Entity<Link>()
              .Property(l => l.Name)
              .HasMaxLength(255)
              .IsRequired();

            builder.Entity<Link>()
              .Property(l => l.Description)
              .HasMaxLength(255)
              .IsRequired();

            builder.Entity<Link>()
              .Property(l => l.TypeLink)
              .IsRequired();


              // participant
            builder.Entity<Participant>()
              .HasKey(p => p.Id);

            builder.Entity<Participant>()
              .Property(p => p.TypeParticipant)
              .HasMaxLength(255)
              .IsRequired();



              // profile
            builder.Entity<Profile>()
              .HasKey(p => p.Id);

            builder.Entity<Profile>()
              .Property(p => p.UserName)
              .HasMaxLength(255)
              .IsRequired();

            builder.Entity<Profile>()
              .Property(p => p.Email)
              .HasMaxLength(255)
              .IsRequired();

            builder.Entity<Profile>()
              .Property(p => p.LastName)
              .HasMaxLength(255)
              .IsRequired();

            builder.Entity<Profile>()
              .Property(p => p.FirstName)
              .HasMaxLength(255)
              .IsRequired();

            builder.Entity<Profile>()
              .Property(p => p.Employeenumber)
              .IsRequired();

      
              // projectmedia
            builder.Entity<Media>()
              .HasKey(p => p.Id);

            builder.Entity<Media>()
              .Property(p => p.Url)
              .HasMaxLength(255)
              .IsRequired();

            builder.Entity<Media>()
              .Property(p => p.TypeMedia)
              .IsRequired();


              // projectstatus
            builder.Entity<Status>()
              .HasKey(p => p.Id);

            builder.Entity<Status>()
              .Property(p => p.Name)
              .HasMaxLength(255)
              .IsRequired();

            builder.Entity<Status>()
              .Property(p => p.Description)
              .HasMaxLength(255)
              .IsRequired();


              // publication
            builder.Entity<Publication>()
              .HasKey(p => p.Id);

            builder.Entity<Publication>()
              .Property(p => p.Name)
              .HasMaxLength(255)
              .IsRequired();

              // spearhead
            builder.Entity<Publication>()
              .HasKey(p => p.Id);

            builder.Entity<Publication>()
              .Property(p => p.Name)
              .HasMaxLength(255)
              .IsRequired();

              // tag
            builder.Entity<Tag>()
              .HasKey(t => t.Id);

            builder.Entity<Tag>()
              .Property(t => t.Name)
              .HasMaxLength(255)
              .IsRequired();
            
            builder.Entity<Tag>()
              .Property(t => t.Description)
              .HasMaxLength(255)
              .IsRequired();

            
        }
    }
}
