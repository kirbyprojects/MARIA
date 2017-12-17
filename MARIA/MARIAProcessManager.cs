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
    }
}
