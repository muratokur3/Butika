using Application.Models.DTOs.User;
using Application.Models.VMs;
using Application.Services.AbstractServices;

namespace Application.Services.ConcreteServices;

public class UserService : IUserService
{
  
    public Task<UserVm> AuthenticateAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserVm>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<UserVm> RegisterAsync(RegisterDto registerDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserVm> UpdateUserAsync(UserDto userDto)
    {
        throw new NotImplementedException();
    }
}
