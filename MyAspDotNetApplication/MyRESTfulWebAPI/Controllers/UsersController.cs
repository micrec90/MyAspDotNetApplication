using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRESTfulWebAPI.Context;
using MyRESTfulWebAPI.DTOs.UserDTOs;
using MyRESTfulWebAPI.Interfaces;
using MyRESTfulWebAPI.Mappers;
using MyRESTfulWebAPI.Models;

namespace MyRESTfulWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;
        private readonly ApplicationDBContext _context;

        public UsersController(ApplicationDBContext context, IUsersRepository userRepository)
        {
            _userRepository = userRepository;
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetDTO>>> GetUsers()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _userRepository.GetAllAsync();
            return users.Select(x => x.ToUserGetDTO()).ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserGetDTO>> GetUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user.ToUserGetDTO();
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUser(int id, UserPutDTO userPutDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.PutAsync(id, userPutDTO);

            if(user == null)
            {
                return NotFound();
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserPostDTO userPostDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = userPostDTO.ToUserFromPostDTO();
            await _userRepository.PostAsync(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user.ToUserGetDTO());
        }

        // DELETE: api/Users/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.DeleteAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
