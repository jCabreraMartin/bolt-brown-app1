using System.Collections.Generic;
using System.Data.SQLite;
using TimeTracking.Data.Models;

namespace TimeTracking.Data
{
    public class ChargeAccountRepository
    {
        public List<ChargeAccount> GetAll()
        {
            var accounts = new List<ChargeAccount>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT Id, Code, Description, Active FROM ChargeAccounts WHERE Active = 1 ORDER BY Code";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(MapChargeAccount(reader));
                        }
                    }
                }
            }
            return accounts;
        }

        public ChargeAccount GetById(int id)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT Id, Code, Description, Active FROM ChargeAccounts WHERE Id = @id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapChargeAccount(reader);
                        }
                    }
                }
            }
            return null;
        }

        public ChargeAccount GetByCode(string code)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                string sql = "SELECT Id, Code, Description, Active FROM ChargeAccounts WHERE Code = @code";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@code", code);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapChargeAccount(reader);
                        }
                    }
                }
            }
            return null;
        }

        public int Insert(ChargeAccount account)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                string sql = "INSERT INTO ChargeAccounts (Code, Description, Active) VALUES (@code, @description, @active); SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@code", account.Code);
                    command.Parameters.AddWithValue("@description", account.Description);
                    command.Parameters.AddWithValue("@active", account.Active ? 1 : 0);

                    return (int)(long)command.ExecuteScalar();
                }
            }
        }

        private ChargeAccount MapChargeAccount(SQLiteDataReader reader)
        {
            return new ChargeAccount
            {
                Id = reader.GetInt32(0),
                Code = reader.GetString(1),
                Description = reader.GetString(2),
                Active = reader.GetInt32(3) == 1
            };
        }
    }
}
