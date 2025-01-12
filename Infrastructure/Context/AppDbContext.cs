using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Kullanıcı ve İşletme ilişkisini tanımlayan tablolara erişim
        public DbSet<User> Users { get; set; }
        public DbSet<Business> Businesses { get; set; }

        // Kullanıcıların favori işletmeleri ile ilgili tabloya erişim
        public DbSet<UserFavoriteBusiness> UserFavoriteBusinesses { get; set; }

        // İşletme ile diğer ilişkili tablolara erişim
        public DbSet<Category> Categories { get; set; }
        public DbSet<BusinessCategory> BusinessCategories { get; set; }
        public DbSet<BusinessContact> BusinessContacts { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BusinessTag> BusinessTags { get; set; }
        public DbSet<BusinessMarketplace> BusinessMarketplaces { get; set; }
        public DbSet<Marketplace> Marketplaces { get; set; }
        public DbSet<BusinessShippingCompany> BusinessShippingCompanies { get; set; }
        public DbSet<ShippingCompany> ShippingCompanies { get; set; }
        public DbSet<BusinessCampaign> BusinessCampaigns { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BusinessSpecialCertification> BusinessSpecialCertifications { get; set; }
        public DbSet<SpecialCertification> SpecialCertifications { get; set; }
        public DbSet<BusinessHighlightFeature> BusinessHighlightFeatures { get; set; }
        public DbSet<HighlightFeature> HighlightFeatures { get; set; }
        public DbSet<BusinessMarketingChannel> BusinessMarketingChannels { get; set; }
        public DbSet<MarketingChannel> MarketingChannels { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite keys
            modelBuilder.Entity<UserFavoriteBusiness>()
                .HasKey(ufb => new { ufb.UserId, ufb.BusinessId });

            modelBuilder.Entity<BusinessCategory>()
                .HasKey(bc => new { bc.BusinessId, bc.CategoryId });

            modelBuilder.Entity<BusinessTag>()
                .HasKey(bt => new { bt.BusinessId, bt.TagId });

            modelBuilder.Entity<BusinessMarketplace>()
                .HasKey(bm => new { bm.BusinessId, bm.MarketplaceId });

            modelBuilder.Entity<BusinessShippingCompany>()
                .HasKey(bsc => new { bsc.BusinessId, bsc.ShippingCompanyId });

            modelBuilder.Entity<BusinessCampaign>()
                .HasKey(bc => new { bc.BusinessId, bc.CampaignId });

            modelBuilder.Entity<BusinessSpecialCertification>()
                .HasKey(bsc => new { bsc.BusinessId, bsc.SpecialCertificationId });

            modelBuilder.Entity<BusinessHighlightFeature>()
                .HasKey(bhf => new { bhf.BusinessId, bhf.HighlightFeatureId });

            // Configure relationships
            modelBuilder.Entity<UserFavoriteBusiness>()
                .HasOne(ufb => ufb.User)
                .WithMany(u => u.UserFavoriteBusinesses)
                .HasForeignKey(ufb => ufb.UserId);

            modelBuilder.Entity<UserFavoriteBusiness>()
                .HasOne(ufb => ufb.Business)
                .WithMany(b => b.UserFavoriteBusinesses)
                .HasForeignKey(ufb => ufb.BusinessId);

            modelBuilder.Entity<BusinessCategory>()
                .HasOne(bc => bc.Business)
                .WithMany(b => b.BusinessCategories)
                .HasForeignKey(bc => bc.BusinessId);

            modelBuilder.Entity<BusinessCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BusinessCategories)
                .HasForeignKey(bc => bc.CategoryId);

            modelBuilder.Entity<BusinessTag>()
                .HasOne(bt => bt.Business)
                .WithMany(b => b.BusinessTags)
                .HasForeignKey(bt => bt.BusinessId);

            modelBuilder.Entity<BusinessTag>()
                .HasOne(bt => bt.Tag)
                .WithMany(t => t.BusinessTags)
                .HasForeignKey(bt => bt.TagId);

            modelBuilder.Entity<BusinessMarketplace>()
                .HasOne(bm => bm.Business)
                .WithMany(b => b.BusinessMarketplaces)
                .HasForeignKey(bm => bm.BusinessId);

            modelBuilder.Entity<BusinessMarketplace>()
                .HasOne(bm => bm.Marketplace)
                .WithMany(m => m.BusinessMarketplaces)
                .HasForeignKey(bm => bm.MarketplaceId);

            modelBuilder.Entity<BusinessShippingCompany>()
                .HasOne(bsc => bsc.Business)
                .WithMany(b => b.BusinessShippingCompanies)
                .HasForeignKey(bsc => bsc.BusinessId);

            modelBuilder.Entity<BusinessShippingCompany>()
                .HasOne(bsc => bsc.ShippingCompany)
                .WithMany(sc => sc.BusinessShippingCompanies)
                .HasForeignKey(bsc => bsc.ShippingCompanyId);

            modelBuilder.Entity<BusinessCampaign>()
                .HasOne(bc => bc.Business)
                .WithMany(b => b.BusinessCampaigns)
                .HasForeignKey(bc => bc.BusinessId);

            modelBuilder.Entity<BusinessCampaign>()
                .HasOne(bc => bc.Campaign)
                .WithMany(c => c.BusinessCampaigns)
                .HasForeignKey(bc => bc.CampaignId);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=A00184508;Database=butika;User Id=sa;Password=12345678;Integrated Security=False;TrustServerCertificate=True;");
        }


    }
}
