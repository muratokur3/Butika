using Application.Models.DTOs.Marketplace;

namespace Application.Services.AbstractServices;

public interface IMarketplaceService
{
    Task CreateAsync(MarketplaceDTO marketplaceDTO);
    Task UpdateAsync(MarketplaceDTO marketplaceDTO);
}
