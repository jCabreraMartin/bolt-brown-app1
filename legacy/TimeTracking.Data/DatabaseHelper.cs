using System;
using System.Data.SQLite;
using System.IO;

namespace TimeTracking.Data
{
    public static class DatabaseHelper
    {
        private static readonly string DbFileName = "TimeTracking.db";
        private static string _dbPath;

        public static string ConnectionString
        {
            get
            {
                string path = GetDatabasePath();
                return string.Format("Data Source={0};Version=3;", path);
            }
        }

        public static string GetDatabasePath()
        {
            if (_dbPath == null)
            {
                _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);
            }
            return _dbPath;
        }

        public static void SetDatabasePath(string path)
        {
            _dbPath = path;
        }

        public static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static void InitializeDatabase()
        {
            string dbPath = GetDatabasePath();
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (var connection = GetConnection())
            {
                string sql = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        FullName TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        Active INTEGER NOT NULL DEFAULT 1
                    );

                    CREATE TABLE IF NOT EXISTS ChargeAccounts (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Code TEXT NOT NULL UNIQUE,
                        Description TEXT NOT NULL,
                        Active INTEGER NOT NULL DEFAULT 1
                    );

                    CREATE TABLE IF NOT EXISTS TimeEntries (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserId INTEGER NOT NULL,
                        ChargeAccountId INTEGER NOT NULL,
                        Date TEXT NOT NULL,
                        Hours REAL NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES Users(Id),
                        FOREIGN KEY (ChargeAccountId) REFERENCES ChargeAccounts(Id),
                        UNIQUE(UserId, ChargeAccountId, Date)
                    );
                ";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
