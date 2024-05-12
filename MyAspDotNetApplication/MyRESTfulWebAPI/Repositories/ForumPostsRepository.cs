using Microsoft.EntityFrameworkCore;
using MyRESTfulWebAPI.Context;
using MyRESTfulWebAPI.DTOs.ForumPostDTOs;
using MyRESTfulWebAPI.DTOs.UserDTOs;
using MyRESTfulWebAPI.Interfaces;
using MyRESTfulWebAPI.Models;
using MyRESTfulWebAPI.Queries;

namespace MyRESTfulWebAPI.Repositories
{
    public class ForumPostsRepository : IForumPostsRepository
    {
        private readonly ApplicationDBContext _context;

        public ForumPostsRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ForumPost?> DeleteAsync(int id)
        {
            var forumPost = await _context.ForumPosts.FirstOrDefaultAsync(x => x.Id == id);

            if (forumPost == null)
                return null;

            _context.ForumPosts.Remove(forumPost);
            await _context.SaveChangesAsync();

            return forumPost;
        }

        public async Task<List<ForumPost>> GetAllAsync(ForumPostQuery queryObject)
        {
            var forumPosts = _context.ForumPosts.AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryObject.Title))
            {
                forumPosts = forumPosts.Where(f => f.Title.Contains(queryObject.Title));
            }
            if (!string.IsNullOrWhiteSpace(queryObject.Content))
            {
                forumPosts = forumPosts.Where(f => f.Content.Contains(queryObject.Content));
            }
            if (!string.IsNullOrWhiteSpace(queryObject.User))
            {
                forumPosts = forumPosts.Where(f => f.User != null && f.User.Username.Contains(queryObject.User));
            }

            if(!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if(queryObject.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    forumPosts = queryObject.IsDescending ? forumPosts.OrderByDescending(x => x.Title) : forumPosts.OrderBy(x => x.Title);
                }
                if (queryObject.SortBy.Equals("Content", StringComparison.OrdinalIgnoreCase))
                {
                    forumPosts = queryObject.IsDescending ? forumPosts.OrderByDescending(x => x.Content) : forumPosts.OrderBy(x => x.Content);
                }
                if (queryObject.SortBy.Equals("User", StringComparison.OrdinalIgnoreCase))
                {
                    forumPosts = queryObject.IsDescending ? forumPosts.OrderByDescending(x => x.User) : forumPosts.OrderBy(x => x.User);
                }
            }

            return await forumPosts.ToListAsync();
        }

        public async Task<ForumPost?> GetByIdAsync(int id)
        {
            return await _context.ForumPosts.FindAsync(id);
        }

        public async Task<ForumPost> PostAsync(ForumPost forumPost)
        {
            await _context.ForumPosts.AddAsync(forumPost);
            await _context.SaveChangesAsync();
            return forumPost;
        }

        public async Task<ForumPost?> PutAsync(int id, ForumPostPutDTO postDTO)
        {
            var forumPost = await _context.ForumPosts.FirstOrDefaultAsync(x => x.Id == id);

            if (forumPost == null)
                return null;

            forumPost.Title = postDTO.Title;
            forumPost.Content = postDTO.Content;

            _context.Entry(forumPost).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return forumPost;
        }
    }
}
