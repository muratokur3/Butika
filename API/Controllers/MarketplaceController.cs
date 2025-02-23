using Application.Models.DTOs.Marketplace;
using Application.Services.AbstractServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarketplaceController : ControllerBase
    {
        private readonly IMarketplaceService _marketplaceService;
        public MarketplaceController(IMarketplaceService marketplaceService)
        {
            _marketplaceService = marketplaceService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMarketplace([FromBody] MarketplaceDTO marketplaceDTO)
        {
            await _marketplaceService.CreateAsync(marketplaceDTO);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMarketplace([FromBody] MarketplaceDTO marketplaceDTO)
        {
            await _marketplaceService.UpdateAsync(marketplaceDTO);
            return Ok();
        }
    }
}
