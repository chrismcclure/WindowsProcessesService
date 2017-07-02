using MonitorService.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MonitorService
{
    public partial class Service1 : ServiceBase
    {

       
        public Service1()
        {
            InitializeComponent();
         

        }

        protected override void OnStart(string[] args)
        {
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
            eventLog1.WriteEntry("In OnStart");
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(20);

            var timer = new System.Threading.Timer((e) =>
            {
                eventLog1.WriteEntry("Tried To run my bits");
                new GetAndEnterNewData();
            }, null, startTimeSpan, periodTimeSpan);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Totally stopped my sweet service");
        }
    }
}
