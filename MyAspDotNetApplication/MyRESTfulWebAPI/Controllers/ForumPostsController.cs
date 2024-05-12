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
        private readonly IUsersRepository _userRepository;
        private readonly ApplicationDBContext _context;

        public ForumPostsController(ApplicationDBContext context, IForumPostsRepository forumPostsRepository, IUsersRepository usersRepository)
        {
            _forumPostsRepository = forumPostsRepository;
            _userRepository = usersRepository;
            _context = context;
        }

        // GET: api/ForumPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumPostGetDTO>>> GetForumPosts()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var forumPosts = await _forumPostsRepository.GetAllAsync();
            return forumPosts.Select(x => x.ToForumPostGetDTO()).ToList();
        }

        // GET: api/ForumPosts/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ForumPostGetDTO>> GetForumPost(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var forumPost = await _forumPostsRepository.GetByIdAsync(id);

            if (forumPost == null)
            {
                return NotFound();
            }

            return forumPost.ToForumPostGetDTO();
        }

        // PUT: api/ForumPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutForumPost(int id, ForumPostPutDTO forumPostPutDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var forumPost = await _forumPostsRepository.PutAsync(id, forumPostPutDTO);

            if (forumPost == null)
            {
                return NotFound();
            }

            if(id !=  forumPost.Id)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/ForumPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userId}")]
        public async Task<ActionResult<ForumPost>> PostForumPost(int userId, ForumPostPostDTO forumPostDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _userRepository.UserExists(userId))
            {
                return BadRequest();
            }

            var forumPost = forumPostDTO.ToForumPostFromPostDTO(userId);
            await _forumPostsRepository.PostAsync(forumPost);

            return CreatedAtAction(nameof(GetForumPost), new { id = forumPost.Id }, forumPost.ToForumPostGetDTO());
        }

        // DELETE: api/ForumPosts/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteForumPost(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var forumPost = await _forumPostsRepository.DeleteAsync(id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool ForumPostExists(int id)
        {
            return _context.ForumPosts.Any(e => e.Id == id);
        }
    }
}
