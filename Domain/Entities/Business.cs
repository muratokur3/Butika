using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Business
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty; 
    public string Description { get; set; } = string.Empty;
    public string SummaryDescription { get; set; } = string.Empty;
    public string LogoUrl { get; set; }
    public int EmployeeCount { get; set; }
    public bool ApprovalStatus { get; set; }= false;
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
    public ICollection<UserFavoriteBusiness> UserFavoriteBusinesses { get; set; } = new List<UserFavoriteBusiness>();
}