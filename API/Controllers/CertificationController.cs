using Application.Models.DTOs.Certification;
using Application.Services.AbstractServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationService _certificationService;
        public CertificationController(ICertificationService certificationService)
        {
            _certificationService = certificationService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCertification([FromBody] CertificationDTO certificationDTO)
        {
            await _certificationService.CreateAsync(certificationDTO);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCertification([FromBody] CertificationDTO certificationDTO)
        {
            await _certificationService.UpdateAsync(certificationDTO);
            return Ok();
        }
    }
}
