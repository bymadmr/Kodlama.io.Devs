using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProgLang.Domain.Entities;

namespace ProgLang.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<UserSocial> DeveloperSocials { get; set; }
        public DbSet<User> Developers { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
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
            modelBuilder.Entity<UserSocial>(a =>
            {
                a.ToTable("DeveloperSocial").HasKey(k => k.Id);
                a.Property(a => a.SocialId).HasColumnName("SocialId");
                a.Property(a => a.UserId).HasColumnName("DeveloperId");
                a.Property(a => a.Url).HasColumnName("Url");
            });
            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Developer").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.FirstName).HasColumnName("FirstName");
                a.Property(a => a.LastName).HasColumnName("LastName");
                a.Property(a => a.Email).HasColumnName("Email");
                a.Property(a => a.PasswordHash).HasColumnName("PasswordHash");
                a.Property(a => a.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(a => a.Status).HasColumnName("Status");
                a.Property(a => a.AuthenticatorType).HasColumnName("AuthenticatorType");
                a.HasMany(p => p.UserOperationClaims);
            });
            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaim").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.UserId).HasColumnName("UserId");
                a.Property(a => a.OperationClaimId).HasColumnName("OperationClaimId");
                a.HasOne(p => p.User).WithMany(x=>x.UserOperationClaims).HasForeignKey(x=>x.UserId);
                a.HasOne(p => p.OperationClaim);
            });
            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaim").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.Name).HasColumnName("Name");
            });
            Language[] languageSeedData = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<Language>().HasData(languageSeedData);

            Technology[] technologySeedData = { new(1, "WPF", "Description", "ImageURL", 1), new(2, "ASPNET", "Descriotion", "ImageURL", 1) };
            modelBuilder.Entity<Technology>().HasData(technologySeedData);

            Social[] socialSeedData = { new(1, "GitHub") };
            modelBuilder.Entity<Social>().HasData(socialSeedData);
        }
    }
}
