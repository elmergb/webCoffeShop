using final_crud.DTOs.User;
using final_crud.Models;
using final_crud.Repositories.Interfaces;
using final_crud.Services.Interfaces;
using BCrypt.Net;
using final_crud.Services.GenerateToken;

namespace final_crud.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly JwtTokenService _jwtTokenService;

        public UserService (IUserRepository repository, JwtTokenService jwtTokenService)
        {
            _repository = repository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<UserResponseDto> RegisterAsync(RegisterUserDto dto)
        {
            var checkEmail = await _repository.GetUserAsync(dto.Email);

            if (checkEmail != null)
            {
                throw new Exception("Email already exists");
            }

            var hashPassword = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash);

            User user = new User
            {
                Email = dto.Email,
                PasswordHash = hashPassword,
                Role = dto.role

            };

            var createdUser =
                await _repository.CreateUserAsync(user);

            return new UserResponseDto
            {
                Id = createdUser.Id,
                Email = createdUser.Email
            };  
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserDto dto)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                return false;

            user.Email = dto.Email;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash);
            user.Role = dto.role;

            await _repository.UpdateAsyncRepo(user);
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _repository.DeleteUserRepo(id);
        }

        public async Task<List<UserResponseDto>> GetAllUserService()
        {
            var users = await _repository.GetAllUsersRepo();

            var list = users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Email = u.Email,
                Role = u.Role,
            }).ToList();

            return list;
        }

        public async Task<UserResponseDto> GetUserByEmail(string email)
        {
            var users = await _repository.GetUserAsync(email);

            if (users == null)
                return null;

            return new UserResponseDto
            {
                Id = users.Id,
                Email = users.Email,
                Role = users.Role
            };
        }

        public async Task<UserResponseDto?> Login(LoginDTO dto)
        {
            var user = await _repository.GetUserAsync(dto.Email);

            if (user == null)
                return null;

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isPasswordValid)
                return null;

            //Console.WriteLine(user.Email);
            //Console.WriteLine(user.Role);
            //Console.WriteLine(user.PasswordHash);

            var token = _jwtTokenService.GenerateJwtToken(user);

            return new UserResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
                Token = token
            };


        }
    }
}
