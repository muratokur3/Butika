using Application.Models.DTOs.Campaign;
using Application.Models.DTOs.Tag;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Application.Services.ConcreteServices;

public class CampaignService : ICampaignService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CampaignService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(CampaignDTO campaignDTO)
    {
        var campaign = _mapper.Map<Campaign>(campaignDTO);
        await _unitOfWork.Campaigns.AddAsync(campaign);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(CampaignDTO campaignDTO)
    {
        var campaign = _mapper.Map<Campaign>(campaignDTO);
         _unitOfWork.Campaigns.Update(campaign);
        await _unitOfWork.CompleteAsync();
    }
}
