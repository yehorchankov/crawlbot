using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlBot.Console.Abstract;

namespace CrawlBot.Console.Concrete
{
    class HtmlSerializer : IHtmlSerializer
    {
        public void SaveOnDisk(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
        }
    }
}
