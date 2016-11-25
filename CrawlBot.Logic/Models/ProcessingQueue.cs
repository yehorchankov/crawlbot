using System.Collections.Generic;

namespace CrawlBot.Logic.Models
{
    public class ProcessingQueue
    {
        public static Queue<HttpContext> Queue { get; set; } = new Queue<HttpContext>();
    }
}
