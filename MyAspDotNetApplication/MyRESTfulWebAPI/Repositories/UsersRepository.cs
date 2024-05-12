using Microsoft.EntityFrameworkCore;
using MyRESTfulWebAPI.Context;
using MyRESTfulWebAPI.DTOs.UserDTOs;
using MyRESTfulWebAPI.Interfaces;
using MyRESTfulWebAPI.Mappers;
using MyRESTfulWebAPI.Models;
using MyRESTfulWebAPI.Queries;

namespace MyRESTfulWebAPI.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDBContext _context;

        public UsersRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllAsync(UserQueryObject queryObject)
        {
            var users = _context.Users.Include(c => c.ForumPosts).AsQueryable();
            if(!string.IsNullOrWhiteSpace(queryObject.UserName))
            {
                users = users.Where(u => u.Username.Contains(queryObject.UserName));
            }
            if (!string.IsNullOrWhiteSpace(queryObject.Email))
            {
                users = users.Where(u => u.Email.Contains(queryObject.Email));
            }

            return await users.ToListAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.Include(c => c.ForumPosts).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<User> PostAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User?> PutAsync(int id, UserPutDTO userPutDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return null;

            user.Username = userPutDTO.Username;
            user.Email = userPutDTO.Email;
            user.Password = userPutDTO.Password;

            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<User?> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return null;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(int id)
        {
            return await _context.Users.AnyAsync(e => e.Id == id);
        }
    }
}
