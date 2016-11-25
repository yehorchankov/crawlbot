using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrawlBot.Core.Abstract;
using CrawlBot.Core.Models;

namespace CrawlBot.Core.Concrete
{
    public class ResponseFailureHandler : Handler
    {
        public override void HandleRequest(HttpContext context)
        {
            if (context.Response.InnerException != null)
            {
                //TODO: handle with Memento -> to queue again!
            }
        }
    }
}
