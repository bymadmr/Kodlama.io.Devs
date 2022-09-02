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
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> languages { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
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
                a.Property(p=>p.Name).HasColumnName("Name");
            });
            Language[] languageSeedData = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<Language>().HasData(languageSeedData);
        }
    }
}
