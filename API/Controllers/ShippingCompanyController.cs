using Application.Models.DTOs.ShippingCompany;
using Application.Services.AbstractServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShippingCompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public ShippingCompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] ShippingCompanyDTO shippingCompanyDTO)
        {
            await _companyService.CreateAsync(shippingCompanyDTO);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCompany([FromBody] ShippingCompanyDTO shippingCompanyDTO)
        {
            await _companyService.UpdateAsync(shippingCompanyDTO);
            return Ok();
        }
    }
}
