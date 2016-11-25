using System;
using CrawlBot.Logic.Abstract;

namespace CrawlBot.Logic.Models
{
    public class HttpRequest : HttpBase
    {
        public HttpRequest(Uri uri) : base(uri)
        {
            
        }
    }
}
