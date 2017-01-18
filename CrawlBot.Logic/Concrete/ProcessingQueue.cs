using System;
using System.Collections.Generic;
using CrawlBot.Logic.Models;

namespace CrawlBot.Logic.Concrete
{
    public class ProcessingQueue
    {
        public static Queue<HttpContext> Queue { get; set; } = new Queue<HttpContext>();
        public static Dictionary<string, DateTime> VisitedSites { get; set; } = new Dictionary<string, DateTime>();
    }
}
