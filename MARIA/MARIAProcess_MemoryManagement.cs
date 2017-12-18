using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace MARIA
{
    public partial class MARIAProcess
    {
        public Dictionary<int, dynamic> MemoryValues { get; set; }
        public IntPtr StartAddress { get; private set; }
        public IntPtr EndAddress { get; set; }
        public StatusObject GetMemoryAddresses()
        {
            StatusObject SO = new StatusObject();
            try
            {
                Console.WriteLine(StartAddress);
                Console.WriteLine(EndAddress);
                Console.WriteLine(EndAddress.ToInt64() - StartAddress.ToInt64());
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "PROCESS_GETMEMORYADDRESSES");
            }
            return SO;
        }
    }
}
