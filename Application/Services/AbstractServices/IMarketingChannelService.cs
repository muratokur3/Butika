using Application.Models.DTOs.MarketingChannel;

namespace Application.Services.AbstractServices
{
    public interface IMarketingChannelService
    {
        Task CreateAsync(MarketingChannelDTO marketingChannelDTO);
        Task UpdateAsync(MarketingChannelDTO marketingChannelDTO);
    }
}
