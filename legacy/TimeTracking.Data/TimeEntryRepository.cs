using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using TimeTracking.Data.Models;

namespace TimeTracking.Data
{
    public class TimeEntryRepository
    {
        public List<TimeEntry> GetByUserAndFortnight(int userId, DateTime startDate, DateTime endDate)
        {
            var entries = new List<TimeEntry>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                string sql = @"SELECT Id, UserId, ChargeAccountId, Date, Hours 
                               FROM TimeEntries 
                               WHERE UserId = @userId 
                                 AND Date >= @startDate 
                                 AND Date <= @endDate
                               ORDER BY ChargeAccountId, Date";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entries.Add(MapEntry(reader));
                        }
                    }
                }
            }
            return entries;
        }

        public void SaveEntry(TimeEntry entry)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                string sql = @"INSERT OR REPLACE INTO TimeEntries (UserId, ChargeAccountId, Date, Hours)
                               VALUES (@userId, @chargeAccountId, @date, @hours)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@userId", entry.UserId);
                    command.Parameters.AddWithValue("@chargeAccountId", entry.ChargeAccountId);
                    command.Parameters.AddWithValue("@date", entry.Date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@hours", (double)entry.Hours);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEntry(int userId, int chargeAccountId, DateTime date)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                string sql = "DELETE FROM TimeEntries WHERE UserId = @userId AND ChargeAccountId = @chargeAccountId AND Date = @date";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@chargeAccountId", chargeAccountId);
                    command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                    command.ExecuteNonQuery();
                }
            }
        }

        private TimeEntry MapEntry(SQLiteDataReader reader)
        {
            return new TimeEntry
            {
                Id = reader.GetInt32(0),
                UserId = reader.GetInt32(1),
                ChargeAccountId = reader.GetInt32(2),
                Date = DateTime.ParseExact(reader.GetString(3), "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Hours = (decimal)reader.GetDouble(4)
            };
        }
    }
}
