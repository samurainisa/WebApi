using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;
using WebApplication2.DTOs;

namespace Server.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClubsController : ControllerBase
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Club>> DeleteClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();

            return club;
        }

        // POST: api/Clubs
        [HttpPost]
        public async Task<ActionResult<Club>> PostClub(CreateClubDto request)
        {
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