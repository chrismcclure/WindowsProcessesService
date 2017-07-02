using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorService.Accessors
{
    public class InteractWithDb
    {
        public static bool InsertProcessDataInDB(List<Process> processes)
        {
            try
            {
                using (var db = new testServicesEntities())
                {
                    foreach (var process in processes)
                    {
                        ProcessData processData = new ProcessData();
                        processData.DiskSpace = process.VirtualMemorySize64;
                        processData.DateTimeOfUsage = DateTime.Now;
                        processData.PropertyName = "VirtualMemorySize64";
                        processData.PropertyName = process.ProcessName;
                        db.ProcessDatas.Add(processData);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                //Log the ex to so I know what is jacked up
                return false;
            }
        }
    }
}
