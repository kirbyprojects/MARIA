using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;
namespace MARIA
{
    public partial class MARIAProcessManager
    {
        public MARIAProcessManager()
        {

        }
        public StatusObject GetProcess(int ProcessID)
        {
            StatusObject SO = new StatusObject();
            try
            {
                Process TargetProcess = Process.GetProcessById(ProcessID);
                
                Console.WriteLine(TargetProcess.ProcessName);
            }
            catch(Exception e)
            {
                SO = new StatusObject();
            }
            return SO;
        }
        public StatusObject GetAllProcesses(string ProcessName)
        {
            StatusObject SO = new StatusObject();
            try
            {
                Process[] Processes = Process.GetProcessesByName(ProcessName);
                foreach(Process ActiveProcess in Processes)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", ActiveProcess.ProcessName, ActiveProcess.Id, ActiveProcess.MainModule.BaseAddress, ActiveProcess.MainModule.ModuleMemorySize, ActiveProcess.StartTime);
                }
            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
