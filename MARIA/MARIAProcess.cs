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
        const int READ = 0x0010;
        public MARIAProcess(string ProcessName)
        {
            this.ProcessName = ProcessName;
        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern IntPtr ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
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
        public StatusObject ReadProcessMemory()
        {
            StatusObject SO = new StatusObject();
            try
            {
                Process TargetProcess = Process.GetProcessesByName(this.ProcessName)[0];
                IntPtr ProcessHandle = OpenProcess(READ, false, TargetProcess.Id);
                int bytesRead = 0;
                byte[] Buffer = new byte[24];
                ReadProcessMemory((int)ProcessHandle, 0xEB0000, Buffer, Buffer.Length, ref bytesRead);
                Console.WriteLine("{0} ({1})", Buffer.ToString(), bytesRead.ToString());
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "PROCESS_READPROCESSMEMORY");
            }
            return SO;
        }
        public StatusObject GetProcesses()
        {
            StatusObject SO = new StatusObject();
            try
            {
                List<Process> ActiveProcessList = Process.GetProcessesByName(this.ProcessName).ToList();
                if(ActiveProcessList.Count > 0)
                {
                    foreach (Process ActiveProcess in ActiveProcessList)
                    {
                        IntPtr ActiveProcessHandle = OpenProcess(READ, false, ActiveProcess.Id);
                        int BytesRead = 0;
                        byte[] Buffer = new byte[4096];
                        
                    }
                }
                else
                {
                    SO = new StatusObject(new Exception(String.Format("Unable to find processes with the name {0}", this.ProcessName)), "PROCESS_GETPROCESSES");
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "PROCESS_GETPROCESSES");
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
