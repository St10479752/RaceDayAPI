using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventEnrollmentsController : ControllerBase
    {
        private readonly RaceDayDbContext _context;

        public EventEnrollmentsController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/EventEnrollments
        [HttpGet]
        public async Task<IActionResult> GetEventEnrollments()
        {
            var enrollments = await _context.EventEnrollments
                .Select(e => new
                {
                    e.EnrollmentID,
                    e.ParticipantID,
                    e.EventID,
                    e.CategoryID,
                    e.EnrolledAt,
                    e.Status
                })
                .ToListAsync();

            return Ok(enrollments);
        }

        // GET: api/EventEnrollments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventEnrollment(int id)
        {
            var enrollment = await _context.EventEnrollments
                .Where(e => e.EnrollmentID == id)
                .Select(e => new
                {
                    e.EnrollmentID,
                    e.ParticipantID,
                    e.EventID,
                    e.CategoryID,
                    e.EnrolledAt,
                    e.Status
                })
                .FirstOrDefaultAsync();

            if (enrollment == null)
            {
                return NotFound();
            }

            return Ok(enrollment);
        }

        // POST: api/EventEnrollments
        [HttpPost]
        public async Task<IActionResult> CreateEventEnrollment(
            EventEnrollment enrollment)
        {
            _context.EventEnrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return Ok(enrollment);
        }

        // PUT: api/EventEnrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEventEnrollment(
            int id, EventEnrollment enrollment)
        {
            if (id != enrollment.EnrollmentID)
            {
                return BadRequest();
            }

            var existingEnrollment =
                await _context.EventEnrollments.FindAsync(id);

            if (existingEnrollment == null)
            {
                return NotFound();
            }

            existingEnrollment.ParticipantID = enrollment.ParticipantID;
            existingEnrollment.EventID = enrollment.EventID;
            existingEnrollment.CategoryID = enrollment.CategoryID;
            existingEnrollment.EnrolledAt = enrollment.EnrolledAt;
            existingEnrollment.Status = enrollment.Status;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/EventEnrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventEnrollment(int id)
        {
            var enrollment =
                await _context.EventEnrollments.FindAsync(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            _context.EventEnrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
