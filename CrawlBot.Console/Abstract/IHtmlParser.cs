using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlBot.Console.Abstract
{
    interface IHtmlParser
    {
        List<string> Filters { get; set; }
    }
}
