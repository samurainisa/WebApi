using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.DTOs;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SportPlacesController : Validating
    {
        private readonly DataContext _context;

        public SportPlacesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SportPlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportPlace>>> GetSportPlaces()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return BadRequest("Token expired, please login again");
            }
            return await _context.SportPlaces.ToListAsync();
        }

        // GET: api/SportPlaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SportPlace>> GetSportPlace(int id)
        {
            var sportPlace = await _context.SportPlaces.FindAsync(id);

            if (sportPlace == null)
            {
                return NotFound();
            }

            return sportPlace;
        }

        // PUT: api/SportPlaces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSportPlace(int id, SportPlace sportPlace)
        {
            if (id != sportPlace.Id)
            {
                return BadRequest();
            }

            _context.Entry(sportPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportPlaceExists(id))
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

        // POST: api/SportPlaces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SportPlace>> PostSportPlace(CreateSportPlaceDto request)
        {

            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return BadRequest("Token expired, please login again");
            }
            var sportPlace = new SportPlace
            {
                Name = request.Name,
                Address = request.Address,
                Capacity = request.Capacity,
                City = request.City,
                Country = request.Country,
                CoverType = request.CoverType
            };

            _context.SportPlaces.Add(sportPlace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSportPlace", new { id = sportPlace.Id }, sportPlace);
        }

        // DELETE: api/SportPlaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSportPlace(int id)
        {
            var sportPlace = await _context.SportPlaces.FindAsync(id);
            if (sportPlace == null)
            {
                return NotFound();
            }

            _context.SportPlaces.Remove(sportPlace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SportPlaceExists(int id)
        {
            return _context.SportPlaces.Any(e => e.Id == id);
        }
    }
}