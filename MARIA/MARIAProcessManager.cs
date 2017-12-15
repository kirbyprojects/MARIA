using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace MARIA
{
    public partial class MARIAProcessManager
    {
        public MARIAProcessManager()
        {

        }
        public StatusObject GetProcesses()
        {
            StatusObject SO = new StatusObject();
            try
            {
                List<Process> ActiveProcessList = Process.GetProcesses().ToList();
                foreach (Process ActiveProcess in ActiveProcessList)
                {
                    Console.WriteLine("{0} {1}", ActiveProcess.ProcessName, ActiveProcess.StartInfo);
                    
                }
            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
