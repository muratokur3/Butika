using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.Business;

public class BusinessBasicInfoDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string SummaryDescription { get; set; } 
    public int EmployeeCount { get; set; }
    public DateTime FoundingDate { get; set; }
    public string SocialImpactDescription { get; set; } 
}
