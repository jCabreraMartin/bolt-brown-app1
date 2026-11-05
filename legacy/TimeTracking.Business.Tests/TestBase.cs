using System;
using System.IO;
using NUnit.Framework;
using TimeTracking.Data;

namespace TimeTracking.Business.Tests
{
    public abstract class TestBase
    {
        protected string TestDbPath;

        [SetUp]
        public void BaseSetUp()
        {
            TestDbPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".db");
            DatabaseHelper.SetDatabasePath(TestDbPath);
            DatabaseHelper.InitializeDatabase();
            DatabaseInitializer.SeedData();
        }

        [TearDown]
        public void BaseTearDown()
        {
            if (File.Exists(TestDbPath))
            {
                try { File.Delete(TestDbPath); }
                catch { }
            }
        }
    }
}
