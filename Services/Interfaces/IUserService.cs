using final_crud.DTOs.User;

namespace final_crud.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> RegisterAsync(RegisterUserDto dto);
        Task<bool> UpdateAsync(int id, UpdateUserDto dto);
        Task<bool> DeleteUser(int id);
        Task<List<UserResponseDto>> GetAllUserService();
        Task<UserResponseDto?> GetUserByEmail(string email);
        Task<UserResponseDto> Login(LoginDTO dto);
    }
}
