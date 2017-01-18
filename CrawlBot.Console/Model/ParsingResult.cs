using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlBot.Console.Model
{
    public class ParsingResult
    {
        public string Uri { get; set; }
        public string Text { get; set; }
        public List<string> Links { get; set; }
    }
}
