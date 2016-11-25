using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrawlBot.Core.Abstract;
using CrawlBot.Core.Models;

namespace CrawlBot.Core.Concrete
{
    public class SuccessfullResponseHandler : Handler
    {
        public override void HandleRequest(HttpContext context)
        {
            var result = context.CallGetRequestAsync();
            if (!result)
            {
                NextHandler.HandleRequest(context);
            }
        }
    }
}
