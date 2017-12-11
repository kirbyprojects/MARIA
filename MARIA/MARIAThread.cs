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
    }
}
