using Domain.Entities;

namespace entrika.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class UserFavoriteBusiness
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int BusinessId { get; set; }
        public Business Business { get; set; } = null!;

        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }

    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int EmployeeCount { get; set; }
        public bool ApprovalStatus { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int BusinessTypeId { get; set; }
        public DateTime FoundingDate { get; set; }
        public string SocialImpactDescription { get; set; } = string.Empty;

        // Navigation Properties
        public BusinessType BusinessType { get; set; } = null!;
        public ICollection<BusinessContact> Contacts { get; set; } = new List<BusinessContact>();
        public ICollection<BusinessTag> BusinessTags { get; set; } = new List<BusinessTag>();
        public ICollection<BusinessMarketplace> BusinessMarketplaces { get; set; } = new List<BusinessMarketplace>();
        public ICollection<BusinessShippingCompany> BusinessShippingCompanies { get; set; } = new List<BusinessShippingCompany>();
        public ICollection<BusinessCampaign> BusinessCampaigns { get; set; } = new List<BusinessCampaign>();
        public ICollection<BusinessSpecialCertification> BusinessSpecialCertifications { get; set; } = new List<BusinessSpecialCertification>();
        public ICollection<BusinessHighlightFeature> BusinessHighlightFeatures { get; set; } = new List<BusinessHighlightFeature>();
        public ICollection<BusinessMarketingChannel> BusinessMarketingChannels { get; set; } = new List<BusinessMarketingChannel>();
        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
        public ICollection<BusinessCategory> BusinessCategories { get; set; } = new List<BusinessCategory>();
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<BusinessCategory> BusinessCategories { get; set; } = new List<BusinessCategory>();
    }

    public class BusinessCategory
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int CategoryId { get; set; }

        // Navigation Properties
        public Business Business { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }

    public class BusinessContact
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string ContactType { get; set; } = string.Empty; // e.g., "Email", "Phone"
        public string ContactValue { get; set; } = string.Empty; // e.g., email address or phone number
        public string Department { get; set; } = string.Empty; // e.g., "Sales", "Support"
        public bool Preferred { get; set; }

        // Navigation Property
        public Business Business { get; set; } = null!;
    }

    public class BusinessType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<Business> Businesses { get; set; } = new List<Business>();
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<BusinessTag> BusinessTags { get; set; } = new List<BusinessTag>();
    }

    public class BusinessTag
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int TagId { get; set; }

        // Navigation Properties
        public Business Business { get; set; } = null!;
        public Tag Tag { get; set; } = null!;
    }

    // Other related entity classes would follow a similar pattern...

    public class BusinessMarketplace
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int MarketplaceId { get; set; }

        // Navigation Properties
        public Business Business { get; set; } = null!;
        public Marketplace Marketplace { get; set; } = null!;
    }

    public class Marketplace
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<BusinessMarketplace> BusinessMarketplaces { get; set; } = new List<BusinessMarketplace>();
    }

    public class BusinessShippingCompany
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int ShippingCompanyId { get; set; }

        // Navigation Properties
        public Business Business { get; set; } = null!;
        public ShippingCompany ShippingCompany { get; set; } = null!;
    }

    public class ShippingCompany
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<BusinessShippingCompany> BusinessShippingCompanies { get; set; } = new List<BusinessShippingCompany>();
    }

    public class BusinessCampaign
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int CampaignId { get; set; }

        // Navigation Properties
        public Business Business { get; set; } = null!;
        public Campaign Campaign { get; set; } = null!;
    }

    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<BusinessCampaign> BusinessCampaigns { get; set; } = new List<BusinessCampaign>();
    }

    public class Branch
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string Location { get; set; } = string.Empty;

        // Navigation Property
        public Business Business { get; set; } = null!;
    }

}
