using final_crud.Repositories.Interfaces;
using final_crud.Data;
using final_crud.Models;
using Microsoft.EntityFrameworkCore;
using final_crud.DTOs;
using final_crud.DTOs.User;

namespace final_crud.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetUserAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateAsyncRepo(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUserRepo(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return false;

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }
        
        public async Task<List<User>> GetAllUsersRepo()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
