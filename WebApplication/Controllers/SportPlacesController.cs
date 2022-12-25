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
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return BadRequest("Token expired, please login again");
            }

            var sportPlace = await _context.SportPlaces.FindAsync(id);

            if (sportPlace == null)
            {
                return NotFound();
            }

            return sportPlace;
        }

        // PUT: api/SportPlaces/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<SportPlace>> PutSportPlace(int id, SportPlace sportPlace)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return BadRequest("Token expired, please login again");
            }

            var sportplace = await _context.SportPlaces.FindAsync(id);

            if (sportplace == null)
            {
                return NotFound();
            }

            sportplace.Name = sportPlace.Name;
            sportplace.Address = sportPlace.Address;
            sportplace.City = sportPlace.City;
            sportplace.Country = sportPlace.Country;
            sportplace.Capacity = sportPlace.Capacity;
            sportplace.CoverType = sportPlace.CoverType;

            await _context.SaveChangesAsync();

            return sportplace;
        }

        // POST: api/SportPlaces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SportPlace>> PostSportPlace(CreateSportPlaceDto request)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            //проверка на такого ще существующего вида спорта
            var checksportPlace = await _context.SportPlaces.FirstOrDefaultAsync(x => x.Name == request.Name);
            if (checksportPlace != null)
            {
                return BadRequest("Такой вид спорта уже существует");
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{sportplacename}")]
        public async Task<ActionResult<SportPlace>> DeleteSportPlace(string sportplacename)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return BadRequest("Token expired, please login again");
            }

            var sportPlace = await _context.SportPlaces.FirstOrDefaultAsync(x => x.Name == sportplacename);

            if (sportPlace == null)
            {
                return NotFound();
            }

            _context.SportPlaces.Remove(sportPlace);
            await _context.SaveChangesAsync();

            return sportPlace;
        }


        private bool SportPlaceExists(int id)
        {
            return _context.SportPlaces.Any(e => e.Id == id);
        }
    }
}