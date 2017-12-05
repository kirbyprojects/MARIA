using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MARIA
{
    public enum FileWriteMode
    {
        APPEND,
        OVERWRITE
    }
    public partial class MARIAFile
    {
        public string FilePath { get; private set; }
        public string FileType { get; private set; }
        public bool IsValid { get; private set; }
        public bool IsMARIAFile { get; private set; }
        public MARIAFile(string FilePath)
        {
            this.FilePath = FilePath;
            this.FileType = Path.GetExtension(FilePath);
            if (File.Exists(FilePath))
            {
                this.IsValid = true;
            }
            else
            {
                this.IsValid = false;
                Console.WriteLine("File Does not Exist");
            }
            if(FileType==".mnf")
            {
                this.IsMARIAFile = true;
            }
        }
    }
}
