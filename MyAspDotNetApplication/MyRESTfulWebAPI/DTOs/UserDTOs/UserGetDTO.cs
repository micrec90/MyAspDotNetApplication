using MyRESTfulWebAPI.DTOs.ForumPostDTOs;
using MyRESTfulWebAPI.Models;

namespace MyRESTfulWebAPI.DTOs.UserDTOs
{
    public class UserGetDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime RegisteredOn { get; set; } = DateTime.Now;
        public List<ForumPostGetDTO> ForumPosts { get; set; } = new List<ForumPostGetDTO>();
    }
}
