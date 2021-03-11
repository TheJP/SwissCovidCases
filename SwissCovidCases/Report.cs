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
            fullyVaccinatedLabel.Text = data.FullyVaccinatedPeople;
            dateLabel.Text = data.Date.ToString("d", CultureInfo.CurrentCulture);
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
