using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Threading;
namespace MARIA
{
    public partial class MARIAFile
    {
        public StatusObject ReadImage()
        {
            StatusObject SO = new StatusObject();
            try
            {
                Image TargetImage = Image.FromFile(this.FilePath);
                Bitmap TargetImageBits = new Bitmap(TargetImage);
                int TargetImageHeight = TargetImage.Height;
                int TargetImageWidth = TargetImage.Width;
                for (int i = 0; i < TargetImageHeight; i++)
                {
                    for(int j = 0; j < TargetImageWidth; j++)
                    {
                        
                    }
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "FILE_READIMAGE");
            }
            return SO;
        }
        public StatusObject DrawImage()
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
        public StatusObject TextFromImage()
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
    }
}
