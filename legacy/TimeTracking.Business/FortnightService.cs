using System;

namespace TimeTracking.Business
{
    public class FortnightService
    {
        public FortnightInfo GetCurrentFortnight()
        {
            return GetFortnightByDate(DateTime.Today);
        }

        public FortnightInfo GetFortnightByDate(DateTime date)
        {
            var info = new FortnightInfo();

            if (date.Day <= 15)
            {
                info.FortnightNumber = 1;
                info.StartDate = new DateTime(date.Year, date.Month, 1);
                info.EndDate = new DateTime(date.Year, date.Month, 15);
            }
            else
            {
                info.FortnightNumber = 2;
                info.StartDate = new DateTime(date.Year, date.Month, 16);
                info.EndDate = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            }

            info.DaysInFortnight = (info.EndDate - info.StartDate).Days + 1;

            return info;
        }

        public string GetDayOfWeekAbbreviation(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return "Mon";
                case DayOfWeek.Tuesday: return "Tue";
                case DayOfWeek.Wednesday: return "Wed";
                case DayOfWeek.Thursday: return "Thu";
                case DayOfWeek.Friday: return "Fri";
                case DayOfWeek.Saturday: return "Sat";
                case DayOfWeek.Sunday: return "Sun";
                default: return "";
            }
        }

        public DateTime[] GetFortnightDays(FortnightInfo fortnight)
        {
            var days = new DateTime[fortnight.DaysInFortnight];
            for (int i = 0; i < fortnight.DaysInFortnight; i++)
            {
                days[i] = fortnight.StartDate.AddDays(i);
            }
            return days;
        }
    }
}
