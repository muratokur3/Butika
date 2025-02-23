using Application.Models.DTOs.HighlightFeature;
using Application.Models.DTOs.Tag;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;

namespace Application.Services.ConcreteServices;

public class FeatureService : IFeatureService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public FeatureService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(HighlightFeatureDTO highlightFeatureDTO)
    {
        var highlightFeature = _mapper.Map<HighlightFeature>(highlightFeatureDTO);
        await _unitOfWork.HighlightFeatures.AddAsync(highlightFeature);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(HighlightFeatureDTO highlightFeatureDTO)
    {
        var highlightFeature = _mapper.Map<HighlightFeature>(highlightFeatureDTO);
         _unitOfWork.HighlightFeatures.Update(highlightFeature);
        await _unitOfWork.CompleteAsync();
    }
}
