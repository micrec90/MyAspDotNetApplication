using Microsoft.EntityFrameworkCore;
using MyRESTfulWebAPI.Context;
using MyRESTfulWebAPI.DTOs.ForumPostDTOs;
using MyRESTfulWebAPI.DTOs.UserDTOs;
using MyRESTfulWebAPI.Interfaces;
using MyRESTfulWebAPI.Models;

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

        public async Task<List<ForumPost>> GetAllAsync()
        {
            return await _context.ForumPosts.ToListAsync();
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
