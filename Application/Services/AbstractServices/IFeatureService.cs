using Application.Models.DTOs.HighlightFeature;

namespace Application.Services.AbstractServices;

public interface IFeatureService
{
    Task CreateAsync(HighlightFeatureDTO highlightFeatureDTO);
    Task UpdateAsync(HighlightFeatureDTO highlightFeatureDTO);
}
