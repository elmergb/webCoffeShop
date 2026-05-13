using System.ComponentModel.DataAnnotations;

namespace final_crud.DTOs.User
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be 6-100 characters")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("PasswordHash", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; } = "User";
    }
}
