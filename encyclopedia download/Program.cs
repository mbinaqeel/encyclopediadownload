using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace encyclopedia_download
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1001;
            string id= "";
            while (i <= 1054)
            {
                if (i < 10)
                    id += "000" + i;
                else if (i < 100)
                    id += "00" + i;
                else if (i < 1000)
                    id += "0" + i;
                else
                    id += "" + i;
                string s = "https://ia800302.us.archive.org/BookReader/BookReaderImages.php?zip=/3/items/UrduDaerahMaarifIslamia/Urdu%20Daerah%20Ma%27arif%20Islamia%20Vol%2002_jp2.zip&file=Urdu%20Daerah%20Ma%27arif%20Islamia%20Vol%2002_jp2/Urdu%20Daerah%20Ma%27arif%20Islamia%20Vol%2002_"+id+".jp2&scale=9.95141065830721&rotate=0";
                WebRequest imgGETURL = WebRequest.Create(s);

                /*         WebProxy myProxya = new WebProxy("172.16.0.6", 80);
                         myProxya.BypassProxyOnLocal = true;

                         imgGETURL.Proxy = WebProxy.GetDefaultProxy();*/

                Stream img = imgGETURL.GetResponse().GetResponseStream();

                int bufferSize = 1000024;
                byte[] buffer = new byte[bufferSize];
                int bytesRead = 0, sum = 0;

                // Read from response and write to file
                FileStream fileStream = File.Create(@"D:\univ. data\FYP\Daira Maarifa Islamia\jpgs\vol 2\" + i + ".jpg");
                while ((bytesRead = img.Read(buffer, 0, bufferSize)) != 0)
                {

                    sum += bytesRead;
                    Console.WriteLine("reading "+id+"  #: " + bytesRead + "  :  " + (sum / 1000.0000).ToString("#,##KB"));


                    fileStream.Write(buffer, 0, bytesRead);
                } // end while
                fileStream.Close();
                i++;
                id = "";
            }

        }
    }
}
