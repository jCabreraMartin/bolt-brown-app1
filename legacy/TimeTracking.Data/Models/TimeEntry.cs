using System;

namespace TimeTracking.Data.Models
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChargeAccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
    }
}
