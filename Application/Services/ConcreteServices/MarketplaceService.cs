using Application.Models.DTOs.Marketplace;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Application.Services.ConcreteServices;

public class MarketplaceService : IMarketplaceService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public MarketplaceService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(MarketplaceDTO marketplaceDTO)
    {
        var marketplace = _mapper.Map<Marketplace>(marketplaceDTO);
        await _unitOfWork.marketplaces.AddAsync(marketplace);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(MarketplaceDTO marketplaceDTO)
    {
        var marketplace = _mapper.Map<Marketplace>(marketplaceDTO);
        _unitOfWork.marketplaces.Update(marketplace);
        await _unitOfWork.CompleteAsync();
    }
}
