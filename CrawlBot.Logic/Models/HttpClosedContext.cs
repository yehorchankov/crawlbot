using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlBot.Logic.Abstract;

namespace CrawlBot.Logic.Models
{
    public class HttpClosedContext : ContextBase
    {
        public HttpClosedContext(Uri uri) : base(uri)
        {
        }


    }
}
