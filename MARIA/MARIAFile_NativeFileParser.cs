using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MARIA
{
    public partial class MARIAFile
    {
        public StatusObject ParseNativeFile()
        {
            StatusObject SO = new StatusObject();
            try
            {
                XmlDocument NativeFile = new XmlDocument();
                NativeFile.Load(this.FilePath);
                string MariaFileType = NativeFile.DocumentElement.Name;
                bool SuccessfullyParsed = true;
                if (MariaFileType == "mariaexecute")
                {
                    foreach(XmlNode NativeFileNode in NativeFile.DocumentElement.ChildNodes)
                    {
                        string CommandType = NativeFileNode.Name;
                        if(CommandType == "mariawebrequest")
                        {
                            string URL = NativeFileNode["url"].InnerText;
                            MARIAWebRequest NewRequest = new MARIAWebRequest(URL);
                            Console.WriteLine(URL);
                        }
                    }
                }
                else
                {
                    SuccessfullyParsed = false;
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "FILE_PARSENATIVEFILE");
            }
            return SO;
        }
    }
}
