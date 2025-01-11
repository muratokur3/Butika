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
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public string ShortDescription { get; set; }
    public string About { get; set; }
    public string WebsiteUrl { get; set; }
    public SocialMediaLinks SocialMediaLinks { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int OwnerId { get; set; }
    public virtual User Owner { get; set; }
}