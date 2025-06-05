
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Entity;
using Api.Infrastructure.Context;
using Api.Dto;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheltersController : ControllerBase
    {
        private readonly GefContext _context;

        public SheltersController(GefContext context)
        {
            _context = context;
        }

        // GET: api/Shelter
        /// <summary>
        /// Get all shelters
        /// </summary>
        /// <response code="200">Return all shelters</response>
        /// <response code="404">No shelter Found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shelter>>> GetShelters()
        {
            try
            {
                var shelters = await _context.Shelters.ToListAsync();
                if (shelters == null || shelters.Count == 0)
                    return NotFound();
                return shelters;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao buscar abrigos: {ex.Message}");
            }
        }

        // GET: api/Shelters/5
        /// <summary>
        /// Get shelter by id
        /// </summary>
        /// <response code="200">Return shelter</response>
        /// <response code="404">No shelter Found</response>
        /// <response code="500">Internal server error</response>        
        [HttpGet("{id}")]
        public async Task<ActionResult<Shelter>> GetShelter(long id)
        {
            try
            {
                var shelter = await _context.Shelters
                    .Include(s => s.Users)
                    .FirstOrDefaultAsync(s => s.ShelterID == id);

                if (shelter == null)
                {
                    return NotFound();
                }

                return shelter;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao buscar abrigo: {ex.Message}");
            }
        }

        // PUT: api/Shelters/5
        /// <summary>
        /// Change shelter by id
        /// </summary>
        /// <response code="204">shelter successfully updated</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No shelter Found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShelter(long id, [FromBody] ShelterDto dto)
        {
            try
            {
                var shelter = await _context.Shelters.FindAsync(id);
                if (shelter == null)
                    return NotFound();

                // Atualize apenas os campos permitidos
                shelter.Name = dto.Name;
                shelter.Address = dto.Address;
                shelter.Quantity = dto.Quantity;
                shelter.Capacity = dto.Capacity;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar abrigo: {ex.Message}");
            }
        }

        // POST: api/Shelters
        /// <summary>
        /// Create new shelter
        /// </summary>
        /// <response code="201">shelter created successfully</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No shelter Found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShelterDto dto)
        {
            try
            {
                var shelter = new Shelter
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Quantity = dto.Quantity,
                    Capacity = dto.Capacity
                };

                _context.Shelters.Add(shelter);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetShelter", new { id = shelter.ShelterID }, shelter);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao criar abrigo: {ex.Message}");
            }
        }

        // DELETE: api/Shelters/5
        /// <summary>
        /// Delete shelters by id
        /// </summary>
        /// <response code="204">shelter successfully removed</response>
        /// <response code="404">No shelter Found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShelter(long id)
        {
            try
            {
                var shelter = await _context.Shelters.FindAsync(id);
                if (shelter == null)
                {
                    return NotFound();
                }

                _context.Shelters.Remove(shelter);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao remover abrigo: {ex.Message}");
            }
        }
    }
}
