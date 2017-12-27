using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Threading;
namespace MARIA
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ProgramRunning = true;
            string StartupMode = "console";
            string UserInput = "";
            MARIAFile ActiveFile = new MARIAFile(args.ElementAtOrDefault(0));
            MARIASqlServerDatabase ActiveDatabase = null;
            HttpClient ApplicationClient = new HttpClient();
            if (ActiveFile.IsValid && ActiveFile.IsMARIAFile)
            {
                StartupMode = "file";
            }
            /*Set UserInput based on File Type*/
            if(StartupMode == "file")
            {
                try
                {
                    ActiveFile.ParseNativeFile();
                    Console.ReadKey();
                }
                catch(Exception e)
                {

                }
            }
            else if (StartupMode == "console")
            {
                while (ProgramRunning)
                {
                    try
                    {
                        Console.Write("Command: ");
                        UserInput = Console.ReadLine();
                        string PrimaryCommand = UserInput.Split(' ').ElementAtOrDefault(0).Trim();
                        string InstructionSet = UserInput.Remove(0, PrimaryCommand.Length).Trim();
                        if (UserInput != "exit")
                        {
                            if (PrimaryCommand == "file")
                            {
                                if (ActiveFile != null && ActiveFile.IsValid)
                                {
                                    string SecondaryCommand = InstructionSet.Split(' ')[0];
                                    if (SecondaryCommand == "open")
                                    {
                                        string FilePath;
                                        Console.Write("Set Active File: ");
                                        FilePath = Console.ReadLine();
                                        ActiveFile = new MARIAFile(FilePath);
                                    }
                                    else if (SecondaryCommand == "imageread")
                                    {
                                        ActiveFile.ReadImage();
                                    }
                                    else if (SecondaryCommand == "clear")
                                    {
                                        ActiveFile = null;
                                    }
                                    else
                                    {
                                        Console.WriteLine("{0} {1} is not a recognized command", PrimaryCommand, SecondaryCommand);
                                    }
                                }
                                else
                                {
                                    string FilePath;
                                    Console.Write("Set Active File: ");
                                    FilePath = Console.ReadLine();
                                    ActiveFile = new MARIAFile(FilePath);
                                }
                            }
                            else if (PrimaryCommand == "database")
                            {
                                if (ActiveDatabase != null)
                                {
                                    string SecondaryCommand = InstructionSet.Split(' ')[0];
                                    string DatabaseCommand = InstructionSet.Remove(0, SecondaryCommand.Length).Trim();
                                    if (SecondaryCommand == "open")
                                    {
                                        string DatabaseCredentials;
                                        Console.Write("Set Active Database: ");
                                        DatabaseCredentials = Console.ReadLine();
                                        ActiveDatabase = new MARIASqlServerDatabase(DatabaseCredentials);
                                    }
                                    else if (SecondaryCommand == "readerquery")
                                    {
                                        StatusObject SO_ReaderQuery = ActiveDatabase.ExecuteReaderQuery(DatabaseCommand);
                                        if (SO_ReaderQuery.Status != StatusCode.FAILURE)
                                        {
                                            ActiveDatabase.DisplayResultSet(SO_ReaderQuery.UDDynamic);
                                        }
                                    }
                                    else if (SecondaryCommand == "executedqueryhistory")
                                    {
                                        StatusObject SO_ExecutedQueryHistory = ActiveDatabase.GetAllExecutedQueries();
                                        if (SO_ExecutedQueryHistory.Status != StatusCode.FAILURE)
                                        {
                                            ActiveDatabase.DisplayResultSet(SO_ExecutedQueryHistory.UDDynamic);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("{0} {1} is not a recognized command", PrimaryCommand, SecondaryCommand);
                                    }
                                }
                                else
                                {
                                    string DatabaseCredentials;
                                    Console.Write("Set Active Database: ");
                                    DatabaseCredentials = Console.ReadLine();
                                    ActiveDatabase = new MARIASqlServerDatabase(DatabaseCredentials);
                                }
                            }
                            else if (PrimaryCommand == "webrequest")
                            {
                                string SecondaryCommand = InstructionSet.Split(' ').ElementAtOrDefault(0);
                                if (SecondaryCommand == "fromfile")
                                {
                                    if (ActiveFile != null)
                                    {
                                        if (ActiveFile.IsValid && ActiveFile.IsMARIAFile)
                                        {
                                            Console.WriteLine("hello");
                                        }
                                    }
                                    else
                                    {
                                        
                                    }
                                }
                                else if (SecondaryCommand == "sequential")
                                {
                                    
                                }
                                else if (SecondaryCommand == "get")
                                {
                                    MARIAWebRequest NewRequest = new MARIAWebRequest("http://uat.merimen.com/uat_id/claims/", WebRequestMethod.GET, ref ApplicationClient);
                                    NewRequest.ConventionalGet(NewRequest.ReadResponse);
                                }
                                else if (SecondaryCommand == "post")
                                {

                                }
                                else
                                {
                                    Console.WriteLine("{0} {1} is not a recognized command", PrimaryCommand, SecondaryCommand);
                                }
                            }
                            else if (PrimaryCommand == "cryptography")
                            {
                                MARIACryptography CryptoTools = new MARIACryptography("abcdefghijklmnopqrstuvwxyz");
                                CryptoTools.GetPermutations();
                            }
                            else if (PrimaryCommand == "crypto2")
                            {
                                Console.BufferHeight = 30000;
                                MARIACryptography CryptoTools = new MARIACryptography("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                                CryptoTools.GetPermutations("A", "AAAA");
                            }
                            else if (PrimaryCommand == "crypto3")
                            {
                                Console.BufferHeight = 30000;
                                string StartSequence = InstructionSet.Split(' ').ElementAtOrDefault(0);
                                int Iterations = Convert.ToInt32(InstructionSet.Split(' ').ElementAtOrDefault(1));
                                MARIACryptography CryptoTools = new MARIACryptography("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                                CryptoTools.GetEndSequence(StartSequence, Iterations);
                            }
                            else if (PrimaryCommand == "tasktest")
                            {
                                MARIATaskManager TaskManager = new MARIATaskManager();
                                MARIATask NewTask = new MARIATask(TaskManager.UserDefinedTask1, "hello");
                                MARIATask NewTask2 = new MARIATask(TaskManager.UserDefinedTask1, "world");
                                MARIATask NewTask3 = new MARIATask(TaskManager.UserDefinedTask2);
                                TaskManager.AddTask("hello", NewTask);
                                TaskManager.AddTask("world", NewTask2);
                                TaskManager.AddTask("hiii", NewTask3);
                                TaskManager.StartTask();
                            }
                            else if (PrimaryCommand == "extdll")
                            {
                                
                            }
                            else if (PrimaryCommand == "thread")
                            {

                            }
                            else if (PrimaryCommand == "process")
                            {
                                MARIAProcess newprocess = new MARIAProcess("chrome");
                                newprocess.Start();
                                newprocess.GetMemoryAddresses();
                            }
                            else if (PrimaryCommand == "process2")
                            {
                                MARIAProcessManager ProcessManager = new MARIAProcessManager();
                                ProcessManager.GetAllProcesses("chrome");
                            }
                            else
                            {
                                Console.WriteLine("{0} is not a recognized command", PrimaryCommand);
                            }
                        }
                        else
                        {
                            ProgramRunning = false;
                            UserInput = null;
                        }
                    }
                    catch (Exception e)
                    {
                        ProgramRunning = false;
                        UserInput = null;
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }
    }
}
