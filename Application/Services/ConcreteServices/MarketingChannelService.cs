using Application.Models.DTOs.MarketingChannel;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Application.Services.ConcreteServices;

public class MarketingChannelService : IMarketingChannelService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public MarketingChannelService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(MarketingChannelDTO marketingChannelDTO)
    {
        var marketinChannel = _mapper.Map<MarketingChannel>(marketingChannelDTO);
        await _unitOfWork.MarketingChannels.AddAsync(marketinChannel);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(MarketingChannelDTO marketingChannelDTO)
    {
        var marketinChannel = _mapper.Map<MarketingChannel>(marketingChannelDTO);
         _unitOfWork.MarketingChannels.Update(marketinChannel);
        await _unitOfWork.CompleteAsync();
    }
}
