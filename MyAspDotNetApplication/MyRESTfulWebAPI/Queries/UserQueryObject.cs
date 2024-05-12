namespace MyRESTfulWebAPI.Queries
{
    public class UserQueryObject
    {
        public string? UserName { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }
}
