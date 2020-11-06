using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SwissCovidCases
{
    public partial class SwissCovidCasesService : ServiceBase
    {
        public SwissCovidCasesService()
        {
            InitializeComponent();
            if (!EventLog.SourceExists(eventLog.Source))
            {
                EventLog.CreateEventSource(eventLog.Source, eventLog.Log);
            }
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("Service Start", EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("Service Stop", EventLogEntryType.Information);
        }
    }
}
