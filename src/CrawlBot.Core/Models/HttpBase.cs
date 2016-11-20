using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlBot.Core.Models
{
    public class HttpBase
    {
        private DateTime _invocationTime;

        public Uri Uri { get; set; }

        public DateTime InvocationTime
        {
            get { return _invocationTime; }
        }

        public HttpBase(Uri uri)
        {
            Uri = uri;
        }
    }
}
