using Application.Models.DTOs;
using Application.Models.VMs;
using Application.Services.AbstractServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BusinessController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IBusinessService _businessService;

    // Dependency Injection ile servislerin ve mapper'ın enjekte edilmesi
    public BusinessController(IMapper mapper, IBusinessService businessService)
    {
        _mapper = mapper;
        _businessService = businessService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllBusinesses()
    {
        var businesses = await _businessService.GetAllBusinessesAsync(); // Veriyi alıyoruz
        var businessVms = _mapper.Map<IEnumerable<BusinessVm>>(businesses); // Veriyi DTO'ya dönüştürüyoruz
        return Ok(businessVms); // JSON formatında döndürüyoruz
    }


    [HttpGet]
    public async Task<IActionResult> GetBusinessById(int id)
    {
        return Ok(await _businessService.GetBusinessByIdAsync(id));
    }


    [HttpPost]
    public async Task<IActionResult> CreateBusiness([FromBody] AddBusinessDto addBusinessDto)
    {
        return Ok( await _businessService.AddBusinessAsync(addBusinessDto));
    }


    [HttpPut]
    public async Task<IActionResult> UpdateBusiness(int id, [FromBody] UpdateBusinessDto updateBusinessDto)
    {
        var updatedBusiness = await _businessService.UpdateBusinessAsync(updateBusinessDto);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBusiness(int id)
    {
        await _businessService.DeleteBusinessAsync(id); 
        return NoContent(); 
    }
}