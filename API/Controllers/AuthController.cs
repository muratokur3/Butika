using Application.Models.DTOs;
using Application.Services.AbstractServices;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            var user = await _userService.RegisterAsync(registerDto);
            return Ok(new { message = "Registration successful" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            var user = await _userService.AuthenticateAsync(loginDto);
            return Ok(new { token = user.Id });// buraya token bilgisi eklenmelidir.
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized();
        }
    }
}