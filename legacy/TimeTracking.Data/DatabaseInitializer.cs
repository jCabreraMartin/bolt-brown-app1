using System;
using System.Data.SQLite;

namespace TimeTracking.Data
{
    public static class DatabaseInitializer
    {
        public static void SeedData()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                using (var checkCmd = new SQLiteCommand("SELECT COUNT(*) FROM Users", connection))
                {
                    long count = (long)checkCmd.ExecuteScalar();
                    if (count > 0) return;
                }

                using (var transaction = connection.BeginTransaction())
                {
                    InsertUser(connection, "jgarcia", "Juan Garcia Lopez", "jgarcia@company.com", "Pass123!");
                    InsertUser(connection, "mrodriguez", "Maria Rodriguez Fernandez", "mrodriguez@company.com", "Pass123!");
                    InsertUser(connection, "clopez", "Carlos Lopez Martin", "clopez@company.com", "Pass123!");
                    InsertUser(connection, "anavarro", "Ana Navarro Ruiz", "anavarro@company.com", "Pass123!");
                    InsertUser(connection, "psanchez", "Pedro Sanchez Gomez", "psanchez@company.com", "Pass123!");

                    InsertChargeAccount(connection, "PROJ-001", "Project Alpha - Development");
                    InsertChargeAccount(connection, "PROJ-002", "Project Beta - Maintenance");
                    InsertChargeAccount(connection, "PROJ-003", "Project Gamma - Consulting");
                    InsertChargeAccount(connection, "INT-001", "Internal Training");
                    InsertChargeAccount(connection, "INT-002", "Internal Meetings");
                    InsertChargeAccount(connection, "INT-003", "Administrative Management");
                    InsertChargeAccount(connection, "VAC-001", "Vacation");
                    InsertChargeAccount(connection, "SIC-001", "Sick Leave");

                    DateTime today = DateTime.Today;
                    DateTime fortnightStart;
                    if (today.Day <= 15)
                    {
                        fortnightStart = new DateTime(today.Year, today.Month, 1);
                    }
                    else
                    {
                        fortnightStart = new DateTime(today.Year, today.Month, 16);
                    }

                    for (int day = 0; day < 5 && (fortnightStart.AddDays(day).Day <= 15 || fortnightStart.Day > 15); day++)
                    {
                        DateTime date = fortnightStart.AddDays(day);
                        if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                        {
                            InsertTimeEntry(connection, 1, 1, date, 6.0);
                            InsertTimeEntry(connection, 1, 5, date, 2.0);
                        }
                    }

                    for (int day = 0; day < 5 && (fortnightStart.AddDays(day).Day <= 15 || fortnightStart.Day > 15); day++)
                    {
                        DateTime date = fortnightStart.AddDays(day);
                        if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                        {
                            InsertTimeEntry(connection, 2, 2, date, 4.0);
                            InsertTimeEntry(connection, 2, 3, date, 3.5);
                            InsertTimeEntry(connection, 2, 4, date, 0.5);
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        private static void InsertUser(SQLiteConnection connection, string username, string fullName, string email, string password)
        {
            string sql = "INSERT INTO Users (Username, FullName, Email, Password, Active) VALUES (@username, @fullName, @email, @password, 1)";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@fullName", fullName);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.ExecuteNonQuery();
            }
        }

        private static void InsertChargeAccount(SQLiteConnection connection, string code, string description)
        {
            string sql = "INSERT INTO ChargeAccounts (Code, Description, Active) VALUES (@code, @description, 1)";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@code", code);
                command.Parameters.AddWithValue("@description", description);
                command.ExecuteNonQuery();
            }
        }

        private static void InsertTimeEntry(SQLiteConnection connection, int userId, int chargeAccountId, DateTime date, double hours)
        {
            string sql = "INSERT OR IGNORE INTO TimeEntries (UserId, ChargeAccountId, Date, Hours) VALUES (@userId, @chargeAccountId, @date, @hours)";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@chargeAccountId", chargeAccountId);
                command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@hours", hours);
                command.ExecuteNonQuery();
            }
        }
    }
}
