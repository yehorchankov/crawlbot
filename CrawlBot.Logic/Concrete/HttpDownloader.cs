using System;
using System.Net.Http;
using System.Threading.Tasks;
using CrawlBot.Logic.Abstract;

namespace CrawlBot.Logic.Concrete
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