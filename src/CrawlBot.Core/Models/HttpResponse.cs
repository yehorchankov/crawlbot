using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlBot.Core.Models
{
    public class HttpResponse : HttpBase
    {
        private string _content;

        public Uri Uri { get; set; }

        public string Content
        {
            get { return _content; }
        }


        public HttpResponse(Uri uri) : base(uri)
        {

        }
    }
}
