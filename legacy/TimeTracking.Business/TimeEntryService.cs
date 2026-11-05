using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TimeTracking.Data;
using TimeTracking.Data.Models;

namespace TimeTracking.Business
{
    public class TimeEntryService
    {
        private readonly TimeEntryRepository _entryRepository;

        public TimeEntryService()
        {
            _entryRepository = new TimeEntryRepository();
        }

        public TimeEntryService(TimeEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public List<TimeEntry> GetFortnightEntries(int userId, FortnightInfo fortnight)
        {
            return _entryRepository.GetByUserAndFortnight(userId, fortnight.StartDate, fortnight.EndDate);
        }

        public bool ValidateHoursFormat(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return true;

            decimal hours;
            if (!decimal.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out hours))
                return false;

            if (hours < 0)
                return false;

            if (hours > 24)
                return false;

            int dotIndex = value.IndexOf('.');
            if (dotIndex >= 0)
            {
                string decimals = value.Substring(dotIndex + 1);
                if (decimals.Length > 1)
                    return false;
            }

            return true;
        }

        public decimal ParseHours(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0;

            decimal hours;
            if (decimal.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out hours))
                return hours;

            return 0;
        }

        public void SaveHours(int userId, int chargeAccountId, DateTime date, decimal hours)
        {
            if (hours == 0)
            {
                _entryRepository.DeleteEntry(userId, chargeAccountId, date);
            }
            else
            {
                var entry = new TimeEntry
                {
                    UserId = userId,
                    ChargeAccountId = chargeAccountId,
                    Date = date,
                    Hours = hours
                };
                _entryRepository.SaveEntry(entry);
            }
        }

        public decimal CalculateTotalByAccount(List<TimeEntry> entries, int chargeAccountId)
        {
            return entries
                .Where(e => e.ChargeAccountId == chargeAccountId)
                .Sum(e => e.Hours);
        }

        public decimal CalculateTotalByDay(List<TimeEntry> entries, DateTime date)
        {
            return entries
                .Where(e => e.Date.Date == date.Date)
                .Sum(e => e.Hours);
        }

        public decimal CalculateGrandTotal(List<TimeEntry> entries)
        {
            return entries.Sum(e => e.Hours);
        }
    }
}
