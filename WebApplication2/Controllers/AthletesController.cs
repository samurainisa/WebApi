using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Server.Data;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AthletesController : ControllerBase
{
    private readonly DataContext _dataContext;

    public AthletesController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    //GET: api/Athletes
    [HttpGet]
    public IActionResult GetAthletes()
    {
        var athletes = _dataContext.Athletes.ToList();
        return Ok(athletes);
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
            return NotFound();
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
        var club = await _dataContext.Clubs.FindAsync(request.ClubId);

        var sport = await _dataContext.Sports.FindAsync(request.SportId);

        var trener = await _dataContext.Trener.FindAsync(request.TrenerId);

        var sportplace = await _dataContext.SportPlaces.FindAsync(request.SportPlaceId);

        if (club == null || sport == null || trener == null || sportplace == null)
        {
            return NotFound();
        }


        var newAthlete = new Athlete
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Club = club,
            Sport = sport,
            Trener = trener,
            SportPlace = sportplace
        };

        _dataContext.Athletes.Add(newAthlete);
        await _dataContext.SaveChangesAsync();

        return await Get(newAthlete.ClubId);
    }
}