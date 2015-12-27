using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace webSitePuller
{
    class Program
    {
        public void downloadImage(string filename, string imageUrl)
        {

        }

        static void Main(string[] args)
        {
            List<string> imageList = new List<string>();

            //Enter the webiste that we want.
            Console.WriteLine("Enter in a webstie");
            string webSite = Console.ReadLine();

            //Enter the name of the folder to save the images in
            Console.WriteLine("What do you want to name your website?");
            string createFileName = Console.ReadLine();

            WebClient targetSite = new WebClient();

            string source = targetSite.DownloadString("https://" + webSite);

            HtmlAgilityPack.HtmlDocument tDocument = new HtmlAgilityPack.HtmlDocument();
            tDocument.LoadHtml(source);

            foreach (var link in tDocument.DocumentNode.Descendants("img").Select(x => x.Attributes["src"]))
            {
                imageList.Add(link.Value.ToString());
            }
            Console.ReadKey();

            string mainFolder = @" C:\Users\Aziz\Desktop";
            string subFolder = System.IO.Path.Combine(mainFolder, createFileName);
            System.IO.Directory.CreateDirectory(subFolder);

            foreach (var newLink in imageList)
            {

            }

        }
    }
}
