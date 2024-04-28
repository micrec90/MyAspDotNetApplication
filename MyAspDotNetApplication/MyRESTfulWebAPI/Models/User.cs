namespace MyRESTfulWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime RegisteredOn { get; set; } = DateTime.Now;
        public List<ForumPost> ForumPosts { get; set; } = new List<ForumPost>();
    }
}
