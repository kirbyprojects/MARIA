using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MARIA
{
    public enum TextReadMode
    {
        READALL,
        READALLASYNC,
        READLINE,
        READLINEASYNC
    }
    public enum TextWriteMode
    {
        APPENDALL,
        APPENDLINE,
        OVERWRITEALL,
        OVERWRITELINE
    }
    public partial class MARIAFile
    {
        public StatusObject ReadText(TextReadMode ReadMode, params Func<string, StatusObject>[] TextProcessingAlgorithms)
        {
            StatusObject SO = new StatusObject();
            try
            {
                FileStream TargetFile = File.Open(this.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                BufferedStream TargetFileBufferedStream = new BufferedStream(TargetFile);
                StreamReader TargetFileReader = new StreamReader(TargetFileBufferedStream);
                if (ReadMode == TextReadMode.READALL)
                {
                    foreach (Func<string, StatusObject> TextProcessingAlgorithm in TextProcessingAlgorithms)
                    {
                        TextProcessingAlgorithm(TargetFileReader.ReadToEnd());
                    }
                }
                else if (ReadMode == TextReadMode.READLINE)
                {
                    string TextLine;
                    while ((TextLine = TargetFileReader.ReadLine()) != null)
                    {
                        foreach (Func<string, StatusObject> TextProcessingAlgorithm in TextProcessingAlgorithms)
                        {
                            TextProcessingAlgorithm(TextLine);
                        }
                    }
                }
                TargetFileReader.Close();
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "FILE_READTEXT");
            }
            return SO;
        }
        public StatusObject WriteText(TextWriteMode WriteMode, string Input)
        {
            StatusObject SO = new StatusObject();
            try
            {
                bool Append = WriteMode == TextWriteMode.APPENDALL || WriteMode == TextWriteMode.APPENDLINE;
                StreamWriter TargetFile = new StreamWriter(this.FilePath, Append);
                if(WriteMode == TextWriteMode.APPENDALL || WriteMode == TextWriteMode.OVERWRITEALL)
                {
                    TargetFile.Write(Input);
                }
                else if (WriteMode == TextWriteMode.APPENDLINE || WriteMode == TextWriteMode.OVERWRITELINE)
                {
                    TargetFile.WriteLine(Input);
                }
                TargetFile.Close();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "FILE_WRITETEXT");
            }
            return SO;
        }
    }
}
