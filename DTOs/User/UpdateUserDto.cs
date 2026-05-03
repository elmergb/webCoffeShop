namespace final_crud.DTOs.User
{
    public class UpdateUserDto
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string role { get; set; }
    }
}
