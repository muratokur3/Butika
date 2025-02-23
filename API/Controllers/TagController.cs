using Application.Models.DTOs.Tag;
using Application.Services.AbstractServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] TagDTO  tagDTO)
        {
            await _tagService.CreateAsync(tagDTO);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTag([FromBody] TagDTO tagDTO)
        {
            await _tagService.UpdateAsync(tagDTO);
            return Ok();
        }
    }
}
