using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRESTfulWebAPI.Context;
using MyRESTfulWebAPI.DTOs.ForumPostDTOs;
using MyRESTfulWebAPI.Interfaces;
using MyRESTfulWebAPI.Mappers;
using MyRESTfulWebAPI.Models;
using MyRESTfulWebAPI.Repositories;

namespace MyRESTfulWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumPostsController : ControllerBase
    {
        private readonly IForumPostsRepository _forumPostsRepository;
        private readonly ApplicationDBContext _context;

        public ForumPostsController(ApplicationDBContext context, IForumPostsRepository forumPostsRepository)
        {
            _forumPostsRepository = forumPostsRepository;
            _context = context;
        }

        // GET: api/ForumPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumPostGetDTO>>> GetForumPosts()
        {
            var forumPosts = await _forumPostsRepository.GetAllAsync();
            return forumPosts.Select(x => x.ToForumPostGetDTO()).ToList();
        }

        // GET: api/ForumPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ForumPostGetDTO>> GetForumPost(int id)
        {
            var forumPost = await _forumPostsRepository.GetByIdAsync(id);

            if (forumPost == null)
            {
                return NotFound();
            }

            return forumPost.ToForumPostGetDTO();
        }

        // PUT: api/ForumPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForumPost(int id, ForumPost forumPost)
        {
            if (id != forumPost.Id)
            {
                return BadRequest();
            }

            _context.Entry(forumPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ForumPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ForumPost>> PostForumPost(ForumPost forumPost)
        {
            _context.ForumPosts.Add(forumPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForumPost", new { id = forumPost.Id }, forumPost);
        }

        // DELETE: api/ForumPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForumPost(int id)
        {
            var forumPost = await _context.ForumPosts.FindAsync(id);
            if (forumPost == null)
            {
                return NotFound();
            }

            _context.ForumPosts.Remove(forumPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForumPostExists(int id)
        {
            return _context.ForumPosts.Any(e => e.Id == id);
        }
    }
}
