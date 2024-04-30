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
        public static ForumPost ToForumPostFromPostDTO(this ForumPostPostDTO forumPostPostDTO, int userId)
        {
            return new ForumPost
            {
                Title = forumPostPostDTO.Title,
                Content = forumPostPostDTO.Content,
                UserId = userId
            };
        }
    }
}
