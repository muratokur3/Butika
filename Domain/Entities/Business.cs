using Domain.Enums;
namespace Domain.Entities;
public class Business
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public ApprovalStatus ApprovalStatus { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    // Opsiyonel Alanlar
    public string? Description { get; set; }
    public string? SummaryDescription { get; set; }
    public string? LogoUrl { get; set; }
    public int? EmployeeCount { get; set; }
    public DateTime? FoundingDate { get; set; }
    public string? SocialImpactDescription { get; set; }


    // Navigation Properties
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
    public ICollection<UserFavoriteBusiness> UserFavoriteBusinesses { get; set; } = new List<UserFavoriteBusiness>();
}
