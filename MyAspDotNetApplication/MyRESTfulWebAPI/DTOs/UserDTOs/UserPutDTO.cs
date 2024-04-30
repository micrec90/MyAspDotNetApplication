using MyRESTfulWebAPI.Models;

namespace MyRESTfulWebAPI.DTOs.UserDTOs
{
    public class UserPutDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
