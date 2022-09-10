using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProgLang.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<DeveloperSocial> DeveloperSocials { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(a =>
            {
                a.ToTable("ProgrammingLanguage").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
            });
            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technology").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.Name).HasColumnName("Name");
                a.Property(a => a.Description).HasColumnName("Description");
                a.Property(a => a.ImageUrl).HasColumnName("ImageUrl");
                a.HasOne(p => p.Language);
            });
            modelBuilder.Entity<Social>(a =>
            {
                a.ToTable("Social").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.Name).HasColumnName("Name");
            });
            modelBuilder.Entity<DeveloperSocial>(a =>
            {
                a.ToTable("DeveloperSocial").HasKey(k => k.Id);
                a.Property(a => a.SocialId).HasColumnName("SocialId");
                a.Property(a => a.DeveloperId).HasColumnName("DeveloperId");
                a.Property(a => a.Url).HasColumnName("Url");
                a.HasOne(p => p.Developer);
                a.HasOne(p => p.Social);
            });
            Language[] languageSeedData = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<Language>().HasData(languageSeedData);

            Technology[] technologySeedData = { new(1, "WPF", "Description", "ImageURL", 1), new(2, "ASPNET", "Descriotion", "ImageURL", 1) };
            modelBuilder.Entity<Technology>().HasData(technologySeedData);

            Social[] socialSeedData = { new(1, "GitHub") };
            modelBuilder.Entity<Social>().HasData(technologySeedData);
        }
    }
}
