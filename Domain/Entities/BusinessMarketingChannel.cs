using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BusinessMarketingChannel
{
    public int BusinessId { get; set; }
    public int MarketingChannelId { get; set; }

    // Navigation Properties
    public Business Business { get; set; } = null!;
    public MarketingChannel MarketingChannel { get; set; } = null!;
}