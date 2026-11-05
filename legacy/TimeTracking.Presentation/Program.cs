using System;
using System.Windows.Forms;
using TimeTracking.Data;

namespace TimeTracking.Presentation
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DatabaseHelper.InitializeDatabase();
            DatabaseInitializer.SeedData();

            Application.Run(new LoginForm());
        }
    }
}
