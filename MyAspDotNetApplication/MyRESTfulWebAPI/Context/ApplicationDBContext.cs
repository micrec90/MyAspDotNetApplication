using Microsoft.EntityFrameworkCore;
using MyRESTfulWebAPI.Models;

namespace MyRESTfulWebAPI.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
    }
}
