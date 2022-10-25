using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportPlacesController : ControllerBase
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