using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisersController : ControllerBase
    {
        private readonly RaceDayDbContext _context;

        public OrganisersController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/Organisers
        [HttpGet]
        public async Task<IActionResult> GetOrganisers()
        {
            var organisers = await _context.Organisers
                .Select(o => new
                {
                    o.OrganiserID,
                    o.UserID,
                    o.OrganisationName,
                    o.ContactNumber
                })
                .ToListAsync();

            return Ok(organisers);
        }

        // GET: api/Organisers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganiser(int id)
        {
            var organiser = await _context.Organisers
                .Where(o => o.OrganiserID == id)
                .Select(o => new
                {
                    o.OrganiserID,
                    o.UserID,
                    o.OrganisationName,
                    o.ContactNumber
                })
                .FirstOrDefaultAsync();

            if (organiser == null)
            {
                return NotFound();
            }

            return Ok(organiser);
        }

        // POST: api/Organisers
        [HttpPost]
        public async Task<IActionResult> CreateOrganiser(Organiser organiser)
        {
            _context.Organisers.Add(organiser);
            await _context.SaveChangesAsync();

            return Ok(organiser);
        }

        // PUT: api/Organisers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganiser(
            int id, Organiser organiser)
        {
            if (id != organiser.OrganiserID)
            {
                return BadRequest();
            }

            var existingOrganiser = await _context.Organisers
                .FindAsync(id);

            if (existingOrganiser == null)
            {
                return NotFound();
            }

            existingOrganiser.UserID = organiser.UserID;
            existingOrganiser.OrganisationName =
                organiser.OrganisationName;
            existingOrganiser.ContactNumber =
                organiser.ContactNumber;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Organisers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganiser(int id)
        {
            var organiser = await _context.Organisers.FindAsync(id);

            if (organiser == null)
            {
                return NotFound();
            }

            _context.Organisers.Remove(organiser);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
