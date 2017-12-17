using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MARIA
{
    public partial class MARIAProcess
    {
        public string ProcessName { get; private set; }
        public Process ProcessInstance { get; private set; }
        public int ProcessID { get; private set; }
        public Dictionary<int,dynamic> MemoryValues { get; set; }
        public IntPtr StartAddress { get; private set; }
        public IntPtr EndAddress { get; set; }
        public MARIAProcess(string ProcessName)
        {
            this.ProcessName = ProcessName;
            this.MemoryValues = new Dictionary<int, dynamic>();
        }
        public StatusObject Start()
        {
            StatusObject SO = new StatusObject();
            try
            {
                this.ProcessInstance = Process.Start(this.ProcessName);
                this.ProcessID = this.ProcessInstance.Id;
                this.StartAddress = this.ProcessInstance.MainModule.BaseAddress;
                this.EndAddress = IntPtr.Add(StartAddress, this.ProcessInstance.MainModule.ModuleMemorySize);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "PROCESS_START");
            }
            return SO;
        }
        public StatusObject Stop()
        {
            StatusObject SO = new StatusObject();
            try
            {
                Process.GetProcessById(this.ProcessID).Kill();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "PROCESS_STOP");
            }
            return SO;
        }
    }
}
