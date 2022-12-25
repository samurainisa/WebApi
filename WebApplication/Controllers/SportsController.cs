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
    public class SportsController : Validating
    {
        private readonly DataContext _context;

        public SportsController(DataContext context)
        {
            _context = context;
        }

        // // GET: api/Sports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSport()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            return await _context.Sports.ToListAsync();
        }


        // GET: api/Sports?name=Football
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSportByName(string name)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            return await _context.Sports.Where(s => s.Name == name).ToListAsync();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPatch]
        public async Task<ActionResult<Sport>> PatchSport(int id, CreateSportDto sportDto)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            var sport = await _context.Sports.FindAsync(id);

            if (sport == null)
            {
                return NotFound();
            }

            sport.Name = sportDto.Name;

            await _context.SaveChangesAsync();

            return sport;
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{sportname}")]
        public async Task<ActionResult<string>> DeleteSport(string sportname)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            var sport = await _context.Sports.Where(s => s.Name == sportname).FirstOrDefaultAsync();
            if (sport == null)
            {
                return NotFound();
            }

            _context.Sports.Remove(sport);
            await _context.SaveChangesAsync();

            return $"Вид спорта {sportname}, Id = {sport.Id} удален";
        }

        // GET: api/Sports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sport>> GetSportById(int id)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            var sport = await _context.Sports.FindAsync(id);

            if (sport == null)
            {
                return NotFound();
            }

            return sport;
        }



        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Sport>> PutSport(int id, CreateSportDto sportdto)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            var sport = await _context.Sports.FindAsync(id);

            if (sport == null)
            {
                return NotFound();
            }

            sport.Name = sportdto.Name;

            await _context.SaveChangesAsync();

            return sport;
        }

        // POST: api/Sports
        [HttpPost]
        public async Task<ActionResult<Sport>> PostSport(CreateSportDto request)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            var newSport = new Sport
            {
                Name = request.Name
            };

            _context.Sports.Add(newSport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSport", new { id = newSport.Id }, newSport);
        }
    }
}