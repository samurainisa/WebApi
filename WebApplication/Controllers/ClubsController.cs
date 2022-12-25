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
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
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
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return BadRequest("Token expired, please login again");
            }
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
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return BadRequest("Token expired, please login again");
            }
            return await _context.Clubs.ToListAsync();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{clubname}")]
        public async Task<ActionResult<string>> DeleteClub(string clubname)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return BadRequest("Token expired, please login again");
            }
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
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Club>> PutClub(int id, CreateClubDto clubDto)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return BadRequest("Token expired, please login again");
            }
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
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            //проверка на такого ще существующего клуба
            var club = await _context.Clubs.Where(c => c.Name == request.Name).FirstOrDefaultAsync();
            if (club != null)
            {
                return BadRequest("Такой клуб уже существует");
            }

            var newClub = new Club
            {
                Name = request.Name
            };

            _context.Clubs.Add(newClub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClub", new { id = newClub.Id }, newClub);
        }

        //запрос для отправки множества клубов в одном запросе
        [HttpPost("PostClubs")]
        public async Task<ActionResult<Club>> PostClubs(CreateClubDto[] request)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);

            }

            //проверка на существование такого же клуба
            var clubs = await _context.Clubs.ToListAsync();
            foreach (var club in clubs)
            {
                foreach (var item in request)
                {
                    if (club.Name == item.Name)
                    {
                        return BadRequest($"Клуб с именем {item.Name} уже существует");
                    }
                }
            }

            foreach (var club in request)
            {
                var newClub = new Club
                {
                    Name = club.Name
                };

                _context.Clubs.Add(newClub);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
        
        

        private bool ClubExists(int id)
        {
            return _context.Clubs.Any(e => e.Id == id);
        }
    }
}