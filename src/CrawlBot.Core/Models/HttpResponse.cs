using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CrawlBot.Core.Models
{
    public class HttpResponse : HttpBase
    {
        public string Content { get; set; }

        public HttpStatusCode ResponseCode { get; set; }


        public HttpResponse(Uri uri) : base(uri)
        {

        }
    }
}
