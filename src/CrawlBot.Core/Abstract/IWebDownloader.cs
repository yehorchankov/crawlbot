using CrawlBot.Core.Models;

namespace CrawlBot.Core.Abstract
{
    internal interface IWebDownloader
    {
        HttpContext GetContent(HttpContext context);
    }
}
