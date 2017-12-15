using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MARIA
{
    public class MARIAThread
    {
        public Thread UserDefinedThread { get; set; }
        public MARIAThread()
        {

        }
        public MARIAThread(Action<string> UserDefinedThread, string ThreadInput)
        {
            this.UserDefinedThread = new Thread(() => UserDefinedThread(ThreadInput));
        }
        public MARIAThread(Func<StatusObject> UserDefinedThread)
        {
            this.UserDefinedThread = new Thread(() => UserDefinedThread());
        }
        public MARIAThread(Func<int, StatusObject> UserDefinedThread, int ThreadInput)
        {
            this.UserDefinedThread = new Thread(() => UserDefinedThread(ThreadInput));
        }
        public StatusObject Start()
        {
            StatusObject SO = new StatusObject();
            try
            {
                this.UserDefinedThread.Start();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "THREAD_START");
            }
            return SO;
        }
        public StatusObject Stop()
        {
            StatusObject SO = new StatusObject();
            try
            {
                this.UserDefinedThread.Abort();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "THREAD_STOP");
            }
            return SO;
        }
    }
}
