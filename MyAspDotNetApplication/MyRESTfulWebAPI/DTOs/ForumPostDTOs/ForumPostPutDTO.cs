using MyRESTfulWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MyRESTfulWebAPI.DTOs.ForumPostDTOs
{
    public class ForumPostPutDTO
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        public string Content { get; set; } = string.Empty;
    }
}
