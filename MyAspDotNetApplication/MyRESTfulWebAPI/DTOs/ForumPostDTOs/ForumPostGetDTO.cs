namespace MyRESTfulWebAPI.DTOs.ForumPostDTOs
{
    public class ForumPostGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
    }
}
