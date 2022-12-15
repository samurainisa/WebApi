using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.Data;
using WebApplication.DTOs;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class ClubsController : Validating
    {
        private readonly DataContext _context;

        public ClubsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubs()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return BadRequest("Token expired, please login again");
            }

            return await _context.Clubs.ToListAsync();
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return club;
        }

        // [Authorize(Roles = "Admin")]
        [HttpPatch]
        public async Task<ActionResult<Club>> PatchClub(int id, CreateClubDto clubDto)
        {
            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            club.Name = clubDto.Name;

            await _context.SaveChangesAsync();

            return club;
        }

        // HEAD: c
        [HttpHead]
        public async Task<ActionResult<IEnumerable<Club>>> HeadClubs()
        {
            return await _context.Clubs.ToListAsync();
        }

        // [Authorize(Roles = "Admin")]
        [HttpDelete("{clubname}")]
        public async Task<ActionResult<string>> DeleteClub(string clubname)
        {
            var club = await _context.Clubs.Where(c => c.Name == clubname).FirstOrDefaultAsync();

            if (club == null)
            {
                return NotFound();
            }

            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();

            return $"Клуб: '{club.Name}, Id = {club.Id} deleted";
        }

        //Put: api/Clubs
        [HttpPut("{id}")]
        public async Task<ActionResult<Club>> PutClub(int id, CreateClubDto clubDto)
        {
            var club = await _context.Clubs.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            club.Name = clubDto.Name;

            await _context.SaveChangesAsync();

            return club;
        }

        // POST: api/Clubs
        [HttpPost]
        public async Task<ActionResult<Club>> PostClub(CreateClubDto request)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return BadRequest("Token expired, please login again");
            }

            var newClub = new Club
            {
                Name = request.Name
            };

            _context.Clubs.Add(newClub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClub", new { id = newClub.Id }, newClub);
        }


        private bool ClubExists(int id)
        {
            return _context.Clubs.Any(e => e.Id == id);
        }
    }
}