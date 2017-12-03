using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIA
{
    public static class MARIAConsole
    {
        public static StatusObject Display(object Input)
        {
            StatusObject SO = new StatusObject();
            try
            {
                Console.WriteLine(Input);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "CONSOLE_DISPLAY");
            }
            return SO;
        }
    }
}
