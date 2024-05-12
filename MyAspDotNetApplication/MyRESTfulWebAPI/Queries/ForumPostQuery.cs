﻿namespace MyRESTfulWebAPI.Queries
{
    public class ForumPostQuery
    {
        public string? Title { get; set; } = null;
        public string? Content { get; set; } = null;
        public string? User { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }
}
