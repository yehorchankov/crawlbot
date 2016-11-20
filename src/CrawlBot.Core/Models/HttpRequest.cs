using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlBot.Core.Models
{
    public class HttpRequest : HttpBase
    {
        public HttpRequest(Uri uri) : base(uri)
        {
            
        }
    }
}
