using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class  MarketingChannel
    {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;

    // Navigation Properties
    public ICollection<BusinessMarketingChannel> BusinessMarketingChannels { get; set; } = new List<BusinessMarketingChannel>();
}