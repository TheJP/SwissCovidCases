using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwissCovidCases
{
    public partial class Report : Form
    {
        public Report(WebScraper.WebScraper.Result data)
        {
            InitializeComponent();
            confirmedCasesLabel.Text = data.NewConfirmedCases;
            hospitalisationsLabel.Text = data.NewHospitalisations;
            confirmedDeathsLabel.Text = data.NewConfirmedDeaths;

            confirmedCasesDailyLabel.Text = DailyValue(data.NewConfirmedCases);
            hospitalisationsDailyLabel.Text = DailyValue(data.NewHospitalisations);
            confirmedDeathsDailyLabel.Text = DailyValue(data.NewConfirmedDeaths);

            fullyVaccinatedLabel.Text = data.VaccinatedPeople;
            dateLabel.Text = data.Date.ToString("d", CultureInfo.CurrentCulture);
            differenceSinceLabel.Text = data.DifferenceSince;
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private string DailyValue(string input) => (int.Parse(RemoveWhitespace(input)) / 7).ToString();

        private string RemoveWhitespace(string input) => string.Join("", input.Trim().Split());
    }
}
