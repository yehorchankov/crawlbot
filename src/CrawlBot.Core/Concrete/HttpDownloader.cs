using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using CrawlBot.Core.Abstract;
using CrawlBot.Core.Models;

namespace CrawlBot.Core.Concrete
{
    public class HttpDownloader : IWebDownloader
    {
        public async Task<string> GetHtmlContent(HttpContext context)
        {
            HttpClient client = new HttpClient();
            var requestResult = await client.GetAsync(context.Request.Uri);
            return await requestResult.Content.ReadAsStringAsync();
        }
    }
}