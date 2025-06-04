using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Entity;
using Api.Infrastructure.Context;
using Api.Dto;

namespace GEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BraceletsController : ControllerBase
    {
        private readonly GefContext _context;

        public BraceletsController(GefContext context)
        {
            _context = context;
        }

        // GET: api/Bracelets
        /// <summary>
        /// Get all Bracelets
        /// </summary>
        /// <response code="200">Return all Bracelets</response>
        /// <response code="404">No bracelets Found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bracelet>>> GetBracelets()
        {
            return await _context.Bracelets.ToListAsync();
        }

        // GET: api/Bracelets/5
        /// <summary>
        /// Get bracelet by id
        /// </summary>
        /// <response code="200">Return all Bracelet</response>
        /// <response code="404">No bracelet Found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Bracelet>> GetBracelet(long id)
        {
            var bracelet = await _context.Bracelets.FindAsync(id);

            if (bracelet == null)
            {
                return NotFound();
            }

            return bracelet;
        }

        // PUT: api/Bracelets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Change bracelet by id
        /// </summary>
        /// <response code="204">bracelet successfully updated</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No bracelet Found</response>
        /// <response code="500">Internal server error</response>       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBracelet(long id, [FromBody] BraceletDto dto)
        {
            var bracelet = await _context.Bracelets.FindAsync(id);
            if (bracelet == null)
                return NotFound();

            // Atualize apenas os campos permitidos
            bracelet.UserId = dto.UserId;
            bracelet.LastBPM = dto.LastBPM;
            bracelet.LastUpdate = dto.LastUpdate;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/Bracelets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Create new bracelet
        /// </summary>
        /// <response code="201">bracelet created successfully</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No bracelet Found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<ActionResult<Bracelet>> PostBracelet([FromBody] BraceletDto dto)
        {
            // Mapeia o DTO para a entidade Bracelet
            var bracelet = new Bracelet
            {
                UserId = dto.UserId,
                LastBPM = dto.LastBPM,
                LastUpdate = dto.LastUpdate
            };

            _context.Bracelets.Add(bracelet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBracelet", new { id = bracelet.BraceletID }, bracelet);
        }


        // DELETE: api/Bracelets/5
        /// <summary>
        /// Delete Bracelet by id
        /// </summary>
        /// <response code="204">bracelet successfully removed</response>
        /// <response code="404">No bracelet Found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBracelet(long id)
        {
            var bracelet = await _context.Bracelets.FindAsync(id);
            if (bracelet == null)
            {
                return NotFound();
            }

            _context.Bracelets.Remove(bracelet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BraceletExists(long id)
        {
            return _context.Bracelets.Any(e => e.BraceletID == id);
        }
    }
}
