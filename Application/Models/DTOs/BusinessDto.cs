using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs;

public class BusinessDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> Tags { get; set; }
    public string ShortDescription { get; set; }
    public string About { get; set; }
    public string WebsiteUrl { get; set; }
    public SocialMediaLinksDto SocialMediaLinks { get; set; }
}
