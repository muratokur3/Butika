using Application.Models.DTOs.MarketingChannel;
using Application.Services.AbstractServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarketingChannelController : ControllerBase
    {
        private readonly IMarketingChannelService _marketingChannelService;
        public MarketingChannelController(IMarketingChannelService marketingChannelService)
        {
            _marketingChannelService = marketingChannelService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMarketingChannel([FromBody] MarketingChannelDTO marketingChannelDTO)
        {
            await _marketingChannelService.CreateAsync(marketingChannelDTO);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMarketingChannel([FromBody] MarketingChannelDTO marketingChannelDTO)
        {
            await _marketingChannelService.UpdateAsync(marketingChannelDTO);
            return Ok();
        }
    }
}
