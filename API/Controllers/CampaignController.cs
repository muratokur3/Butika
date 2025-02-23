using Application.Models.DTOs.Campaign;
using Application.Services.AbstractServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
       private readonly ICampaignService _campaignService;
        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCampaign([FromBody] CampaignDTO campaignDTO)
        {
            var result =  _campaignService.CreateAsync(campaignDTO);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCampaign([FromBody] CampaignDTO campaignDTO)
        {
            var result = _campaignService.UpdateAsync(campaignDTO);
            return Ok(result);
        }

    }
}
