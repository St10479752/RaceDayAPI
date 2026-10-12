namespace RaceDayAPI.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public int EventID { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public decimal Distance { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }
        public decimal EntryFee { get; set; }

        public Event? Event { get; set; }

        public ICollection<EventEnrollment> EventEnrollments { get; set; } = new List<EventEnrollment>();
    }
}