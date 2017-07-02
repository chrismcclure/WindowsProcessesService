using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorService.Engines
{
    public static class GetProcesses
    {
        public static List<Process> GetProcessInfo()
        {
            return Process.GetProcesses().ToList();
        }
    }
}
