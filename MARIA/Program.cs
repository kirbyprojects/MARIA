using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
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
            if (ActiveFile.MARIAFileType == "webrequestfile")
            {
                UserInput = "webrequest fromfile";
                StartupMode = "file";
            }
            /*Set UserInput based on File Type*/
            if(StartupMode == "file")
            {
                try
                {
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
                                        if (ActiveFile.IsValid && ActiveFile.IsMARIAFile && ActiveFile.MARIAFileType == "webrequestfile")
                                        {
                                            Console.WriteLine("hello");
                                            MARIAWebRequest WebRequest = new MARIAWebRequest(ActiveFile);
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("{0} {1} is not a recognized command", PrimaryCommand, SecondaryCommand);
                                }
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
