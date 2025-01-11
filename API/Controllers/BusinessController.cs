using Application.Models.DTOs;
using Application.Models.VMs;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
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

    // GET api/business
    [HttpGet]
    public async Task<IActionResult> GetAllBusinesses()
    {
        var businesses = await _businessService.GetAllBusinessesAsync(); // Veriyi alıyoruz
        var businessVms = _mapper.Map<List<BusinessVm>>(businesses); // Veriyi DTO'ya dönüştürüyoruz
        return Ok(businessVms); // JSON formatında döndürüyoruz
    }

    // GET api/business/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBusiness(int id)
    {
        var business = await _businessService.GetBusinessByIdAsync(id); // ID ile işletme alıyoruz
        if (business == null)
        {
            return NotFound(); // Eğer bulamazsa 404 döndürüyoruz
        }
        var businessVm = _mapper.Map<BusinessVm>(business);
        return Ok(businessVm); // İşletmeyi DTO'ya dönüştürüp geri gönderiyoruz
    }

    // POST api/business
    [HttpPost]
    public async Task<IActionResult> CreateBusiness([FromBody] CreateBusinessVm createBusinessVm)
    {
        if (createBusinessVm == null)
        {
            return BadRequest(); // Eğer body boşsa 400 döndürüyoruz
        }

        var businessDto = _mapper.Map<AddBusinessDto>(createBusinessVm); // DTO'ya dönüştürüyoruz
        var createdBusiness = await _businessService.AddBusinessAsync(businessDto); // Servisteki işlemi çağırıyoruz

        return CreatedAtAction(nameof(GetBusiness), new { id = createdBusiness.Id }, createdBusiness); // 201 Created döndürüyoruz
    }

    // PUT api/business/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBusiness(int id, [FromBody] UpdateBusinessVm updateBusinessVm)
    {
        if (updateBusinessVm == null || id != updateBusinessVm.Id)
        {
            return BadRequest(); // Eğer id uyuşmazsa 400 döndürüyoruz
        }

        var businessDto = _mapper.Map<UpdateBusinessDto>(updateBusinessVm); // DTO'ya dönüştürüyoruz
        var updatedBusiness = await _businessService.UpdateBusinessAsync(businessDto); // Güncellemeyi yapıyoruz

        if (updatedBusiness == null)
        {
            return NotFound(); // Eğer işletme bulunamazsa 404 döndürüyoruz
        }

        return NoContent(); // 204 No Content döndürüyoruz
    }

    // DELETE api/business/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBusiness(int id)
    {
        var business = await _businessService.GetBusinessByIdAsync(id); // ID ile işletme alıyoruz
        if (business == null)
        {
            return NotFound(); // Eğer işletme yoksa 404 döndürüyoruz
        }

        await _businessService.DeleteBusinessAsync(id); // İşletmeyi siliyoruz
        return NoContent(); // 204 No Content döndürüyoruz
    }
}