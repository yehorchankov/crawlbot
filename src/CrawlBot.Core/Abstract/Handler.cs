using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrawlBot.Core.Models;

namespace CrawlBot.Core.Abstract
{
    public abstract class Handler
    {
        protected Handler NextHandler;

        public void SetNextHandler(Handler nextHandler)
        {
            NextHandler = nextHandler;
        }

        public abstract void HandleRequest(HttpContext context);
    }
}
