using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.DTOs;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrenersController : ControllerBase
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
            return await _context.Trener.ToListAsync();
        }

        [HttpPatch]
        public async Task<ActionResult<Trener>> PatchTrener(int id, CreateTrenerDto trenerDto)
        {
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
            var trener = await _context.Trener.FindAsync(id);

            if (trener == null)
            {
                return NotFound();
            }

            return trener;
        }

        // PUT: api/Treners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrener(int id, Trener trener)
        {
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

        // POST: api/Treners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trener>> PostTrener(CreateTrenerDto request)
        {
            var sport = await _context.Sports.FirstOrDefaultAsync(x => x.Name == request.sportname);
            // var sport = await _context.Sports.FindAsync(request.SportId);
            if (sport == null)
            {
                return BadRequest("Sport not found");
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

        // DELETE: api/Treners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrener(int id)
        {
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