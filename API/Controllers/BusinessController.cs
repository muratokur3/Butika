
using Application.Models.VMs;
using Application.Models.DTOs;
using Application.Services.AbstractServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Application.Models.DTOs.Business;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BusinessController : ControllerBase
{
    private readonly IBusinessService _businessService;
    public BusinessController( IBusinessService businessService)
    {
        _businessService = businessService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllBusinesses()
    {
        var businesses = await _businessService.GetAllBusinessesAsync();
        return Ok(businesses);
    }


    [HttpPost]
    public async Task<IActionResult> CreateBusiness([FromBody] RegisterBusinessDTO registerBusinessDTO)
    {
   await _businessService.AddBusinessAsync(registerBusinessDTO);
    return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBusiness([FromBody] BusinessBasicInfoDTO businessBasicInfoDTO)
    {
        var business = await _businessService.UpdateBusinessBasicInfoAsync(businessBasicInfoDTO);
        return Ok(business);
    }

}