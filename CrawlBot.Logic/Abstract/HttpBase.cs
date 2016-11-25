using System;

namespace CrawlBot.Logic.Abstract
{
    public abstract class HttpBase
    {
        public Guid Id { get; set; }

        public Uri Uri { get; set; }

        public DateTime InvocationTime { get; set; }

        public HttpBase(Uri uri)
        {
            Uri = uri;
        }
    }
}
