using Application.Models.DTOs.User;
using Application.Models.VMs;

namespace Application.Services.AbstractServices
{
    public interface IUserService
    {
        Task<UserVm> RegisterAsync(RegisterDto registerDto);
        Task<UserVm> AuthenticateAsync(LoginDto loginDto);
        Task<UserDto> GetByIdAsync(int userId);
        Task<IEnumerable<UserVm>> GetAllUsersAsync();
        Task<UserVm> UpdateUserAsync(UserDto userDto);
        Task<bool> DeleteUserAsync(int userId);
    }
}
