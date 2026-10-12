namespace RaceDayAPI.Models
{
    public class EventEnrollment
    {
        public int EnrollmentID { get; set; }

        public int ParticipantID { get; set; }

        public int EventID { get; set; }

        public int CategoryID { get; set; }

        public DateTime EnrolledAt { get; set; }

        public string Status { get; set; } = string.Empty;

        public Participant? Participant { get; set; }

        public Event? Event { get; set; }

        public Category? Category { get; set; }

        public Result? Result { get; set; }
    }
}