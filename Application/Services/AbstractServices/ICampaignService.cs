using Application.Models.DTOs.Campaign;


namespace Application.Services.AbstractServices;

public interface ICampaignService
{
    Task CreateAsync(CampaignDTO campaignDTO);
    Task UpdateAsync(CampaignDTO campaignDTO);
}
