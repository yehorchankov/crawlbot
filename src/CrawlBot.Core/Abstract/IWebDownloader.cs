using System.Threading.Tasks;
using CrawlBot.Core.Models;

namespace CrawlBot.Core.Abstract
{
    internal interface IWebDownloader
    {
        Task<string> GetHtmlContent(HttpContext context);
    }
}
