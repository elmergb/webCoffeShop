namespace final_crud.DTOs.User
{
    public class UserResponseDtoV2
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
