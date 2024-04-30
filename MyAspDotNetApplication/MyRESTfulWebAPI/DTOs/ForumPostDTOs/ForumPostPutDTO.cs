using MyRESTfulWebAPI.Models;

namespace MyRESTfulWebAPI.DTOs.ForumPostDTOs
{
    public class ForumPostPutDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
