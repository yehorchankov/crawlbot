using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrawlBot.Logic.Abstract
{
    internal interface IWebDownloader
    {
        Task<HttpResponseMessage> GetHtmlContent(Uri uri);
    }
}
