using MonitorService.Accessors;
using MonitorService.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorService.Managers
{
    class GetAndEnterNewData
    {
        public GetAndEnterNewData()
        {
            var processes = GetProcesses.GetProcessInfo();
            var didItWork = InteractWithDb.InsertProcessDataInDB(processes);
            //do something with did it work
        }
    }
}
