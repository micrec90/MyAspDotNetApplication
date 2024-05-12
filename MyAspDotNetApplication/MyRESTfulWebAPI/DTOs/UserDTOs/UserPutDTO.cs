using MyRESTfulWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MyRESTfulWebAPI.DTOs.UserDTOs
{
    public class UserPutDTO
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MinLength(1)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
    }
}
