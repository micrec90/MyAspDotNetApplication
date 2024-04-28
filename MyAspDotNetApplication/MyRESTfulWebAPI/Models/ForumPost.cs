namespace MyRESTfulWebAPI.Models
{
    public class ForumPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
