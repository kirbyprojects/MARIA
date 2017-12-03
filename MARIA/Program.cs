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
            /*HttpClient ApplicationHttpClient = new HttpClient();
            MARIAWebRequest TargetSite = new MARIAWebRequest("https://indonesia.merimen.com/claims/index.cfm?fusebox=MTRreportsI&fuseaction=dsp_custom&RPTNAME=dsp_pivotmain.cfm&ProcessRpt=1&dl=0&CFID=3322076&CFTOKEN=ce895f2b64d6d32f-D20F34A6-155D-B8AC-03500B0FF3A1FD0E&USID=8189&RID=1313732&BR=700513*&DRFROM=01%2F12%2F2017&DRTO=02%2F12%2F2017&DATEBY=1");
            TargetSite.Get(ApplicationHttpClient);
            MARIAWebRequest TargetSite2 = new MARIAWebRequest("");
            TargetSite2.AddPostParameter("hello", "world");
            TargetSite2.Post(ApplicationHttpClient);*/
            /*MARIAFile TargetFile = new MARIAFile(@"D:\shawn.txt");
            TargetFile.ReadText(TextReadMode.READLINE, MARIAFile.AnalyzeRequest);
            Console.WriteLine(TargetFile.FileType);*/

            /*MARIACryptography CryptoTools = new MARIACryptography();
            Console.WriteLine(CryptoTools.GetHash(HashAlgorithm.MD5, "MARINES_54"));*/
            MARIAFile ImageFile = new MARIAFile(@"C:\Users\User-G56J\Pictures\Screenshots\Screenshot (1543).png");
            MARIAFile ImageFile2 = new MARIAFile(@"C:\Users\User-G56J\Desktop\cute vids for dyana\tumblr_oss7sq7pkg1rhrsjdo2_540.png");
            ImageFile2.ReadImage();
        }
    }
}
