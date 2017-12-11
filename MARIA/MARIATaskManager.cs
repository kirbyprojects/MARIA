using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIA
{
    public class MARIATaskManager
    {
        public Dictionary<string, MARIATask> AvailableTasks { get; set; }
        public MARIATaskManager()
        {
            this.AvailableTasks = new Dictionary<string, MARIATask>();
        }
        public StatusObject StartTask(params string[] TaskNames)
        {
            StatusObject SO = new StatusObject();
            try
            {
                Parallel.ForEach(AvailableTasks, (AvailableTask) =>
                {
                    Console.WriteLine(AvailableTask.Key);
                    AvailableTask.Value.Start();
                });
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "TASKMANAGER_STARTTASKS");
            }
            return SO;
        }
        public StatusObject AddTask(string NewTaskName, MARIATask NewTask)
        {
            StatusObject SO = new StatusObject();
            try
            {
                AvailableTasks.Add(NewTaskName, NewTask);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "TASKMANAGER_ADDTASK");
            }
            return SO;
        }
        public void UserDefinedTask1(string TaskParameter)
        {
            while (true)
            {
                Console.WriteLine(TaskParameter);
            }
        }
        public StatusObject UserDefinedTask2()
        {
            while (true)
            {
                Console.WriteLine("UserDefinedTask2");
            }
        }
    }
}
