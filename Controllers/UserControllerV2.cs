using final_crud.DTOs.User;
using final_crud.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace final_crud.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class UserControllerV2 : ControllerBase
    {
        private readonly IUserService _service;

        public UserControllerV2(IUserService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _service.Login(dto);

            var response = new UserResponseDtoV2
            {
                Id = result.Id,
                Email = result.Email,
                Role = result.Role,
                Token = result.Token,
                LoginTime = DateTime.UtcNow
            };

            return Ok(response);
        }
    }
}
