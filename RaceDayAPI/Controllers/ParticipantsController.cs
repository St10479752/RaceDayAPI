using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly RaceDayDbContext _context;

    public ParticipantsController(RaceDayDbContext context)
        {
            _context = context;
        }

        // GET: api/participants
        [HttpGet]
        public async Task<IActionResult> GetParticipants()
        {
            var participants = await _context.Participants
                .Select(p => new
                {
                    p.ParticipantID,
                    p.UserID,
                    p.PhoneNumber,
                    p.DateOfBirth,
                    p.Gender
                })
                .ToListAsync();

            return Ok(participants);
        }

        // GET: api/participants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipant(int id)
        {
            var participant = await _context.Participants
                .Where(p => p.ParticipantID == id)
                .Select(p => new
                {
                    p.ParticipantID,
                    p.UserID,
                    p.PhoneNumber,
                    p.DateOfBirth,
                    p.Gender
                })
                .FirstOrDefaultAsync();

            if (participant == null)
            {
                return NotFound("Participant not found.");
            }

            return Ok(participant);
        }

        // POST: api/participants
        [HttpPost]
        public async Task<IActionResult> CreateParticipant(
            Participant participant)
        {
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Participant created successfully.",
                participant.ParticipantID,
                participant.UserID,
                participant.PhoneNumber,
                participant.DateOfBirth,
                participant.Gender
            });
        }

        // PUT: api/participants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipant(
            int id, Participant participant)
        {
            if (id != participant.ParticipantID)
            {
                return BadRequest("Participant ID does not match.");
            }

            var existingParticipant = await _context.Participants
                .FindAsync(id);

            if (existingParticipant == null)
            {
                return NotFound("Participant not found.");
            }

            existingParticipant.UserID = participant.UserID;
            existingParticipant.PhoneNumber = participant.PhoneNumber;
            existingParticipant.DateOfBirth = participant.DateOfBirth;
            existingParticipant.Gender = participant.Gender;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/participants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var participant = await _context.Participants.FindAsync(id);

            if (participant == null)
            {
                return NotFound("Participant not found.");
            }

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
