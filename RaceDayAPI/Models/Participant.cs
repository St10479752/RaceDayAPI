namespace RaceDayAPI.Models
{
    public class Participant
    {
        public int ParticipantID { get; set; }

        public int UserID { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; } = string.Empty;

        public User? User { get; set; }
    }
}