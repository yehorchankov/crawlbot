using System;
using System.Net.Http;
using System.Threading.Tasks;
using CrawlBot.Core.Models;

namespace CrawlBot.Core.Abstract
{
    internal interface IWebDownloader
    {
        Task<HttpResponseMessage> GetHtmlContent(Uri uri);
    }
}
