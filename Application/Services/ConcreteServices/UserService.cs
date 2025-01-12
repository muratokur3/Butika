using Application.Models.DTOs.User;
using Application.Models.VMs;
using Application.Services.AbstractServices;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositorys.AbstractRepositories;
using Microsoft.Extensions.Configuration;

namespace Application.Services.ConcreteServices;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<UserVm> AuthenticateAsync(LoginDto loginDto)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(loginDto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.PasswordHash, user.PasswordHash))
            throw new UnauthorizedAccessException("Geçersiz kullanıcı bilgileri.");

        return _mapper.Map<UserVm>(user);
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null) throw new Exception("Kullanıcı bulunamadı.");

        return await _unitOfWork.Users.DeleteAsync(user);
    }

    public async Task<IEnumerable<UserVm>> GetAllUsersAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return _mapper.Map<IEnumerable<UserVm>>(users);
    }

    public async Task<UserDto> GetByIdAsync(int userId)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserVm> RegisterAsync(RegisterDto registerDto)
    {
        var user = _mapper.Map<User>(registerDto);
        // Şifreyi hash'leme işlemi
        //user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

        var newUser = await _unitOfWork.Users.AddAsync(user);

        if (newUser == null) throw new Exception("Kullanıcı kaydedilemedi.");

        return _mapper.Map<UserVm>(newUser);
    }

    public async Task<UserVm> UpdateUserAsync(UserDto userDto)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userDto.Id);
        if (user == null) throw new Exception("Kullanıcı bulunamadı.");
        var updateUser = _unitOfWork.Users.UpdateAsync(user);
        return _mapper.Map<UserVm>(updateUser);
    }


    //private string GenerateJwtToken(User user)
    //{
    //    var claims = new[]
    //    {
    //        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
    //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //        //new Claim(ClaimTypes.Name, user.Name),
    //        new Claim("UserId", user.Id.ToString())
    //    };

    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
    //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //    var token = new JwtSecurityToken(
    //        issuer: _configuration["Jwt:Issuer"],
    //        audience: _configuration["Jwt:Audience"],
    //        claims: claims,
    //        expires: DateTime.Now.AddDays(1),
    //        signingCredentials: creds
    //    );

    //    return new JwtSecurityTokenHandler().WriteToken(token);
    //}


}
