using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.Business;
public class BusinessDetailDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BusinessType { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
    public int CampaignCount { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public DateTime FoundingDate { get; set; }
    public List<string> Tags { get; set; }
    public List<string> Certifications { get; set; }
    public List<string> MarketingChannels { get; set; }
}