using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Entity;
using Api.Infrastructure.Context;
using Api.Dto.Api.Dto;
using Api.Domain.Enum;

namespace GEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GefContext _context;

        public UsersController(GefContext context)
        {
            _context = context;
        }

        // GET: api/Users
        /// <summary>
        /// Get all user
        /// </summary>
        /// <response code="200">Return all user</response>
        /// <response code="404">No user Found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <response code="200">Return all user</response>
        /// <response code="404">No user Found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Change User by id
        /// </summary>
        /// <response code="204">User successfully updated</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No User Found</response>
        /// <response code="500">Internal server error</response> 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, [FromBody] UserDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            // Atualize apenas os campos permitidos
            user.Name = dto.Name;
            user.Age = dto.Age;
            user.Gender = dto.Gender;
            user.BloodType = dto.BloodType;
            user.Weight = dto.Weight;
            user.ResponsableName = dto.ResponsableName;
            user.CPF = dto.CPF;
            user.CardNumber = dto.CardNumber;
            user.UserType = dto.UserType;
            user.ShelterID = dto.ShelterID;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Create new user
        /// </summary>
        /// <response code="201">User created successfully</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No User Found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Age = dto.Age,
                Gender = dto.Gender,
                BloodType = dto.BloodType,
                Weight = dto.Weight,
                ResponsableName = dto.ResponsableName,
                CPF = dto.CPF,
                CardNumber = dto.CardNumber,
                UserType = dto.UserType,
                ShelterID = dto.ShelterID

            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <response code="204">users successfully removed</response>
        /// <response code="404">No users Found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
