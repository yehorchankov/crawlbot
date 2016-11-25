using System;

namespace CrawlBot.Core.Abstract
{
    public abstract class HttpBase
    {
        public Uri Uri { get; set; }

        public DateTime InvocationTime { get; set; }

        public HttpBase(Uri uri)
        {
            Uri = uri;
        }
    }
}
