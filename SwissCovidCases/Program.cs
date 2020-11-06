using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwissCovidCases
{
    static class Program
    {
        private static string LastCheckFile => $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\swisscovidcases_lastcheck.txt";

        private static Timer timer;
        private static DateTime? lastCheck = null;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += async (object sender, EventArgs e) => await TickAsync(sender, e);
            timer.Start();

            Application.Run();
        }

        private static DateTime? LastCheck()
        {
            if (lastCheck == null)
            {
                if (File.Exists(LastCheckFile) &&
                    DateTime.TryParseExact(File.ReadAllText(LastCheckFile), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var date))
                {
                    lastCheck = date;
                }
            }
            return lastCheck;
        }

        private static async Task TickAsync(object sender, EventArgs e)
        {
            var last = LastCheck();
            if (last == null || last < DateTime.Today)
            {
                timer.Stop();
                WebScraper.WebScraper.Result? result = null;
                try
                {
                    result = await WebScraper.WebScraper.Scrape();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show($"Error while trying to load covid updates: {ex.Message}", "Error - Swiss Covid Cases", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                // Adjust timer if it is too early in the morning
                if (result != null && last >= result.Date && DateTime.Now.Hour < 7)
                {
                    timer.Interval = 60 * 60 * 1000;  // 1h
                }
                else
                {
                    timer.Interval = 5 * 60 * 1000;  // 5min
                }

                if (result != null && (last == null || last < result.Date))
                {
                    lastCheck = result.Date;
                    File.WriteAllText(LastCheckFile, result.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                    new Report(result).Show();
                }
                timer.Start();
            }
            else
            {
                timer.Interval = 6 * 60 * 60 * 1000;  // 6h
            }
        }
    }
}
