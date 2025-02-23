using Application.Models.DTOs.Contact;
using Application.Models.DTOs.Tag;
using Application.Services.AbstractServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static QRCoder.PayloadGenerator.SwissQrCode;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactDTO contactDTO)
        {
            await _contactService.CreateAsync(contactDTO);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact([FromBody] ContactDTO contactDTO)
        {
            await _contactService.UpdateAsync(contactDTO);
            return Ok();
        }

    }
}
