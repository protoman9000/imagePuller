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
        static void Main(string[] args)
        {
            List<string> imageList = new List<string>();

            //Enter the webiste that we want.
            Console.WriteLine("Enter in a webstie");
            string webSite = Console.ReadLine();
            WebClient targetSite = new WebClient();

            string source = targetSite.DownloadString("https://" + webSite);

            HtmlAgilityPack.HtmlDocument tDocument = new HtmlAgilityPack.HtmlDocument();
            tDocument.LoadHtml(source);

            foreach (var link in tDocument.DocumentNode.Descendants("img").Select(x => x.Attributes["src"]))
            {
                imageList.Add(link.Value.ToString());
            }
            Console.ReadKey();
        }
    }
}
