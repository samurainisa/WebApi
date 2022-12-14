using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.DTOs;
using WebApplication.Models;

namespace WebApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AthletesController : Validating
{
    private readonly DataContext _dataContext;

    public AthletesController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    //GET: api/Athletes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Athlete>>> GetAthletes()
    {
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        if (ValidateToken(token) == false)
        {
            return BadRequest("Token expired, please login again");
        }

        return await _dataContext.Athletes.ToListAsync();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Athlete>> Get(int id)
    {
        var athlete = await _dataContext.Athletes.FindAsync(id);

        if (athlete == null)
        {
            return NotFound();
        }

        return Ok(athlete);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Athlete>> Delete(int id)
    {
        var athlete = await _dataContext.Athletes.FindAsync(id);

        if (athlete == null)
        {
            return NotFound();
        }

        _dataContext.Athletes.Remove(athlete);
        await _dataContext.SaveChangesAsync();

        return Ok(athlete);
    }

    [HttpPatch]
    public async Task<ActionResult<Athlete>> PatchAthlete(int id, CreateAthleteDto athleteDto)
    {
        var athlete = await _dataContext.Athletes.FindAsync(id);

        if (athlete == null)
        {
            return BadRequest("Athlete not found");
        }

        athlete.FirstName = athleteDto.FirstName;
        athlete.LastName = athleteDto.LastName;
        athlete.ClubId = athleteDto.ClubId;
        athlete.SportId = athleteDto.SportId;
        athlete.TrenerId = athleteDto.TrenerId;
        athlete.SportPlaceId = athleteDto.SportPlaceId;

        await _dataContext.SaveChangesAsync();
        return athlete;
    }

    [HttpPost]
    public async Task<ActionResult<Athlete>> Create(CreateAthleteDto request)
    {
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        if (ValidateToken(token) == false)
        {
            return BadRequest("Token expired, please login again");
        }

        var clubname = await _dataContext.Clubs.FirstOrDefaultAsync(x => x.Name == request.ClubName);
        var sportname = await _dataContext.Sports.FirstOrDefaultAsync(x => x.Name == request.SportName);
        var trenersname = await _dataContext.Trener.FirstOrDefaultAsync(x => x.LastName == request.TrenerName);
        var sportplacename = await _dataContext.SportPlaces.FirstOrDefaultAsync(x => x.Name == request.SportPlaceName);

        if (clubname == null || sportname == null || trenersname == null || sportplacename == null)
        {
            return BadRequest("Invalid data");
        }

        var newAthlete = new Athlete
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Club = clubname,
            Sport = sportname,
            Trener = trenersname,
            SportPlace = sportplacename
        };

        _dataContext.Athletes.Add(newAthlete);
        await _dataContext.SaveChangesAsync();

        return CreatedAtAction("Get", new { id = newAthlete.Id }, newAthlete);
    }
}