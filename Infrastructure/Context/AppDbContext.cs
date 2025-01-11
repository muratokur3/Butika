using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SocialMediaLinks> SocialMediaLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Business ilişkisi: Bir User birden fazla Business ekleyebilir
            modelBuilder.Entity<Business>()
                .HasOne(b => b.Owner)
                .WithMany(u => u.Businesses)
                .HasForeignKey(b => b.OwnerId);

            // Business - Tag ilişkisi: Bir Business birden fazla Tag'e sahip olabilir
            modelBuilder.Entity<Tag>()
                .HasOne(t => t.Business)
                .WithMany(b => b.Tags)
                .HasForeignKey(t => t.BusinessId);

            // Business - SocialMediaLinks ilişkisi: Bir Business'ın bir SocialMediaLinks kaydı olabilir
            modelBuilder.Entity<SocialMediaLinks>()
                .HasOne(s => s.Business)
                .WithOne(b => b.SocialMediaLinks)
                .HasForeignKey<SocialMediaLinks>(s => s.BusinessId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=; Database=; Integrated Security=True; TrustServerCertificate=True;");
        }

        
    }
}
