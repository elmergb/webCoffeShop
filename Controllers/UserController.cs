using Microsoft.AspNetCore.Mvc;
using final_crud.Services.Interfaces;
using final_crud.DTOs;
using final_crud.DTOs.User;
using Microsoft.AspNetCore.Authorization;

namespace final_crud.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
                var result =
                    await _service.RegisterAsync(dto);
                return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto dto)
        {
                var result = await _service.UpdateAsync(id, dto);
                if (!result)
                    return NotFound("User not found");

                return Ok("User successfully updated");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleteUser = await _service.DeleteUser(id);

            if (!deleteUser)
                return NotFound("User Not Found");

            return Ok("User successfully deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.GetAllUserService();
            return Ok(users);
        }

        [HttpGet("{Email}")]
        public async Task<IActionResult> GetByEmail(string Email)
        {
            var user = await _service.GetUserByEmail(Email);

            if (user == null)
                return NotFound("User Not Found");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
                var token = await _service.Login(dto);
                return Ok(token);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return Ok("Protected route");
        }
    }
}
