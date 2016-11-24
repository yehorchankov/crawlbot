using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlBot.Core.Models
{
    public class HttpBase
    {
        public Uri Uri { get; set; }

        public DateTime InvocationTime { get; set; }

        public HttpBase(Uri uri)
        {
            Uri = uri;
        }
    }
}
