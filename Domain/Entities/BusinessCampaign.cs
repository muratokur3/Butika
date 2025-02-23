using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BusinessCampaign
{
    public int BusinessId { get; set; }
    public int CampaignId { get; set; }

    // Navigation Properties
    public Business Business { get; set; } = null!;
    public Campaign Campaign { get; set; } = null!;
}