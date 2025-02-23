using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.VMs;

public class BusinessDetailVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? LogoUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? Description { get; set; }
    public string? SummaryDescription { get; set; }
    public int? EmployeeCount { get; set; }
    public DateTime? FoundingDate { get; set; }
    public string? SocialImpactDescription { get; set; }
    public ApprovalStatus? ApprovalStatus { get; set; }

}
