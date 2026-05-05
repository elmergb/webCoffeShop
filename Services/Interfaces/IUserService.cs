using final_crud.DTOs.User;

namespace final_crud.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDtoV1> RegisterAsync(RegisterUserDto dto);
        Task<bool> UpdateAsync(int id, UpdateUserDto dto);
        Task<bool> DeleteUser(int id);
        Task<List<UserResponseDtoV1>> GetAllUserService();
        Task<UserResponseDtoV1?> GetUserByEmail(string email);
        Task<LoginResult> Login(LoginDTO dto);
    }
}
