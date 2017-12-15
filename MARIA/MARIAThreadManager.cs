using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MARIA
{
    public partial class MARIAThreadManager
    {
        public Dictionary<string, MARIAThread> AvailableThreads { get; private set; }
        public MARIAThreadManager()
        {
            this.AvailableThreads = new Dictionary<string, MARIAThread>();
        }
        public StatusObject AddThread(string NewThreadName, MARIAThread NewThread)
        {
            StatusObject SO = new StatusObject();
            try
            {
                this.AvailableThreads.Add(NewThreadName, NewThread);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "THREADMANAGER_ADDTHREAD");
            }
            return SO;
        }
        public StatusObject StartThread(string ThreadName)
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
        public StatusObject StopThread(string ThreadName)
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
        public StatusObject StartAllThreads()
        {
            StatusObject SO = new StatusObject();
            try
            {
                Parallel.ForEach(this.AvailableThreads, (AvailableThread) =>
                {
                    Console.WriteLine(AvailableThread.Key);
                    AvailableThread.Value.Start();
                });
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "THREADMANAGER_STARTALLTHREADS");
            }
            return SO;
        }
        public StatusObject StopAllThreads()
        {
            StatusObject SO = new StatusObject();
            try
            {
                Parallel.ForEach(this.AvailableThreads, (AvailableThread) =>
                {
                    AvailableThread.Value.Stop();
                });
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "THREADMANAGER_STOPALLTHREADS");
            }
            return SO;
        }
        public StatusObject TestThread1()
        {
            StatusObject SO = new StatusObject();
            try
            {
                while (true)
                {
                    Console.WriteLine("Thread1");
                }
            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject TestThread2()
        {
            StatusObject SO = new StatusObject();
            try
            {
                while (true)
                {
                    Console.WriteLine("Thread2");
                }
            }
            catch (Exception e)
            {

            }
            return SO;
        }
        public StatusObject TestThread3()
        {
            StatusObject SO = new StatusObject();
            try
            {
                while (true)
                {
                    Console.WriteLine("Thread3");
                }
            }
            catch (Exception e)
            {

            }
            return SO;
        }
    }
}
