using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlBot.Core.Models
{
    public class HttpContext
    {
        public HttpRequest Request { get; }
        public HttpResponse Response { get; }

        public HttpContext(string uri) : this(new Uri(uri))
        {
            
        }

        public HttpContext(Uri uri)
        {
            Request = new HttpRequest(uri);
            Response = new HttpResponse(uri);
        }
    }
}
