using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlBot.Console.Abstract
{
    public interface IHtmlSerializer
    {
        void SaveOnDisk(string fileName, string content);
    }
}
