using MyRESTfulWebAPI.DTOs.ForumPostDTOs;
using MyRESTfulWebAPI.DTOs.UserDTOs;
using MyRESTfulWebAPI.Models;
using MyRESTfulWebAPI.Queries;

namespace MyRESTfulWebAPI.Interfaces
{
    public interface IForumPostsRepository
    {
        Task<List<ForumPost>> GetAllAsync(ForumPostQuery queryObject);
        Task<ForumPost?> GetByIdAsync(int id);
        Task<ForumPost> PostAsync(ForumPost forumPost);
        Task<ForumPost?> PutAsync(int id, ForumPostPutDTO postDTO);
        Task<ForumPost?> DeleteAsync(int id);
    }
}
