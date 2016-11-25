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
        public async Task<HttpResponseMessage> GetHtmlContent(Uri uri)
        {
            HttpClient client = new HttpClient();
            return await client.GetAsync(uri);
        }
    }
}