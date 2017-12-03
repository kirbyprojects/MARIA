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
            string UserInput;
            MARIAFile ActiveFile = null;
            while (ProgramRunning)
            {
                try
                {
                    Console.Write("Command: ");
                    UserInput = Console.ReadLine();
                    string PrimaryCommand = UserInput.Split(' ')[0].Trim();
                    string InstructionSet = UserInput.Remove(0, PrimaryCommand.Length).Trim();
                    if(UserInput != "exit")
                    {
                        if(PrimaryCommand == "file")
                        {
                            if(ActiveFile != null)
                            {
                                string SecondaryCommand = InstructionSet.Split(' ')[0];
                                if(SecondaryCommand == "open")
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
                    }
                    else
                    {
                        ProgramRunning = false;
                        UserInput = null;
                    }
                }
                catch(Exception e)
                {
                    ProgramRunning = false;
                    UserInput = null;
                }
            }
        }
    }
}
