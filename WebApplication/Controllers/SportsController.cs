using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.DTOs;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
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
            return await _context.Sports.ToListAsync();
        }


        // GET: api/Sports?name=Football
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSportByName(string name)
        {
            return await _context.Sports.Where(s => s.Name == name).ToListAsync();
        }

        [HttpPatch]
        public async Task<ActionResult<Sport>> PatchSport(int id, CreateSportDto sportDto)
        {
            var sport = await _context.Sports.FindAsync(id);

            if (sport == null)
            {
                return NotFound();
            }

            sport.Name = sportDto.Name;

            await _context.SaveChangesAsync();

            return sport;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sport>> DeleteSport(int id)
        {
            var sport = await _context.Sports.FindAsync(id);
            if (sport == null)
            {
                return NotFound();
            }

            _context.Sports.Remove(sport);
            await _context.SaveChangesAsync();

            return sport;
        }

        // GET: api/Sports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sport>> GetSportById(int id)
        {
            var sport = await _context.Sports.FindAsync(id);

            if (sport == null)
            {
                return NotFound();
            }

            return sport;
        }


        // POST: api/Sports
        [HttpPost]
        public async Task<ActionResult<Sport>> PostSport(CreateSportDto request)
        {
            var newSport = new Sport
            {
                Name = request.Name
            };

            _context.Sports.Add(newSport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSport", new { id = newSport.Id }, newSport);
        }


        private bool SportExists(int id)
        {
            return _context.Sports.Any(e => e.Id == id);
        }
    }
}