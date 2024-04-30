using MyRESTfulWebAPI.DTOs.ForumPostDTOs;
using MyRESTfulWebAPI.Models;

namespace MyRESTfulWebAPI.Mappers
{
    public static class ForumPostMapper
    {
        public static ForumPostGetDTO ToForumPostGetDTO(this ForumPost forumPost)
        {
            return new ForumPostGetDTO
            {
                Id = forumPost.Id,
                Title = forumPost.Title,
                Content = forumPost.Content,
                CreatedOn = forumPost.CreatedOn,
                UserId = forumPost.UserId
            };
        }
    }
}
