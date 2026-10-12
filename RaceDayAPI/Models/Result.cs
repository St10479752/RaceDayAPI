namespace RaceDayAPI.Models
{
    public class Result
    {
        public int ResultID { get; set; }

        public int EnrollmentID { get; set; }

        public int Position { get; set; }

        public TimeSpan FinishTime { get; set; }

        public EventEnrollment? EventEnrollment { get; set; }
    }
}