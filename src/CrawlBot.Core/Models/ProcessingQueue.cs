using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlBot.Core.Models
{
    public class ProcessingQueue
    {
        public static Queue<HttpContext> Queue { get; set; } = new Queue<HttpContext>();
    }
}
