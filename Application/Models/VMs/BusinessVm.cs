using Application.Models.DTOs.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.VMs;
public class BusinessVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<TagDto> Tags { get; set; }
    public string ShortDescription { get; set; }
    public string About { get; set; }
    public string WebsiteUrl { get; set; }
    public SocialMediaLinksDto SocialMediaLinks { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int OwnerId { get; set; }
    public UserDto Owner { get; set; }
}
