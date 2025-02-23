using Application.Models.DTOs.HighlightFeature;
using Application.Services.AbstractServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HighLihtFeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        public HighLihtFeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature([FromBody] HighlightFeatureDTO highlightFeatureDTO)
        {
            await _featureService.CreateAsync(highlightFeatureDTO);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature([FromBody] HighlightFeatureDTO highlightFeatureDTO)
        {
            await _featureService.UpdateAsync(highlightFeatureDTO);
            return Ok();
        }
    }

}
