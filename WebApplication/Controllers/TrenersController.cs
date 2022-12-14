using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.DTOs;
using WebApplication.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrenersController : Validating
    {
        private readonly DataContext _context;

        public TrenersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Treners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trener>>> GetTreners()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            return await _context.Trener.ToListAsync();
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch]
        public async Task<ActionResult<Trener>> PatchTrener(int id, CreateTrenerDto trenerDto)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            var trener = await _context.Trener.FindAsync(id);

            if (trener == null)
            {
                return NotFound();
            }

            trener.FirstName = trenerDto.FirstName;
            trener.LastName = trenerDto.LastName;
            trener.SportId = trenerDto.SportId;

            await _context.SaveChangesAsync();

            return trener;
        }

        // GET: api/Treners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trener>> GetTrener(int id)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            var trener = await _context.Trener.FindAsync(id);

            if (trener == null)
            {
                return NotFound();
            }

            return trener;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrener(int id, Trener trener)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            if (id != trener.Id)
            {
                return BadRequest();
            }

            _context.Entry(trener).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrenerExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Trener>> PostTrener(CreateTrenerDto request)
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                if (ValidateToken(token) == false)
                {
                    return StatusCode(StatusCodes.Status403Forbidden);
                }

                var sport = await _context.Sports.FirstOrDefaultAsync(x => x.Name == request.sportname);

                if (sport == null || sport.Id == 0)
                {
                    return BadRequest("Sport not found");
                }

                //проверка на такого ще существующего тренера
                var trener = await _context.Trener.FirstOrDefaultAsync(x =>
                    x.FirstName == request.FirstName && x.LastName == request.LastName && x.SportId == sport.Id);

                if (trener != null)
                {
                    return BadRequest("Такой тренер уже существует");
                }

                var newTrener = new Trener
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Sport = sport
                };

                _context.Trener.Add(newTrener);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTrener", new { id = newTrener.Id }, newTrener);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex: {ex.Message}");
                return StatusCode((int)HttpStatusCode.Forbidden, "Время сеанса вышло. Зайдите в аккаунт заново.");
            }
        }

        // DELETE: api/Treners/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrener(int id)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (ValidateToken(token) == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            var trener = await _context.Trener.FindAsync(id);
            if (trener == null)
            {
                return NotFound();
            }

            _context.Trener.Remove(trener);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrenerExists(int id)
        {
            return _context.Trener.Any(e => e.Id == id);
        }
    }
}