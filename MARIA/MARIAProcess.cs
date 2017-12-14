using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MARIA
{
    public partial class MARIAProcess
    {
        public string ProcessName { get; private set; }
        public MARIAProcess(string ProcessName)
        {
            this.ProcessName = ProcessName;
        }
        
        public StatusObject Start()
        {
            StatusObject SO = new StatusObject();
            try
            {
                Process.Start(this.ProcessName);
            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject GetProcessFiles()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
