using System.Collections.Generic;
using System.Data.SQLite;
using TimeTracking.Data.Models;

namespace TimeTracking.Data
{
    public class UserRepository
    {
        public User GetByCredentials(string username, string password)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT Id, Username, FullName, Email, Password, Active FROM Users WHERE Username = @username AND Password = @password AND Active = 1";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapUser(reader);
                        }
                    }
                }
            }
            return null;
        }

        public User GetById(int id)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT Id, Username, FullName, Email, Password, Active FROM Users WHERE Id = @id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapUser(reader);
                        }
                    }
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            var users = new List<User>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT Id, Username, FullName, Email, Password, Active FROM Users WHERE Active = 1";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(MapUser(reader));
                        }
                    }
                }
            }
            return users;
        }

        private User MapUser(SQLiteDataReader reader)
        {
            return new User
            {
                Id = reader.GetInt32(0),
                Username = reader.GetString(1),
                FullName = reader.GetString(2),
                Email = reader.GetString(3),
                Password = reader.GetString(4),
                Active = reader.GetInt32(5) == 1
            };
        }
    }
}
