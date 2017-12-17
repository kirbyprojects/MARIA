using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIA
{
    public class MARIATask
    {
        public Task UserDefinedTask { get; set; }
        public StatusObject TaskStatus { get; set; }
        public MARIATask()
        {

        }
        public MARIATask(Action<string> UserDefinedTask, string TaskParameter)
        {
            this.UserDefinedTask = new Task(() => UserDefinedTask(TaskParameter));
        }
        public MARIATask(Action<int> UserDefinedTask, int TaskParameter)
        {
            this.UserDefinedTask = new Task(() => UserDefinedTask(TaskParameter));
        }
        public MARIATask(Func<StatusObject> UserDefinedTask)
        {
            this.UserDefinedTask = new Task(() => 
            {
                UserDefinedTask();
            });
        }
        public MARIATask(Func<string, int, StatusObject> UserDefinedTask, string TaskParameter1, int TaskParameter2)
        {
            this.UserDefinedTask = new Task(() =>
            {
                UserDefinedTask(TaskParameter1, TaskParameter2);
            });
        }
        public StatusObject Start()
        {
            StatusObject SO = new StatusObject();
            try
            {
                UserDefinedTask.Start();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "TASK_START");
            }
            return SO;
        }
    }
}
