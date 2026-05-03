using final_crud.DTOs.User;
using final_crud.Models;

namespace final_crud.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User?> GetUserAsync(string email);
        Task<User?> UpdateAsyncRepo(User user);
        Task<User?> GetByIdAsync(int id);
        Task<bool> DeleteUserRepo(int id);
        Task<List<User>> GetAllUsersRepo();
    }
}
