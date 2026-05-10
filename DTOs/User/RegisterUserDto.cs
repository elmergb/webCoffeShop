using System.ComponentModel.DataAnnotations;

namespace final_crud.DTOs.User
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "email is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be 3-100 characters")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3-50 characters")]
        public string PasswordHash { get; set; }
        public string role { get; set; }
    }
}
