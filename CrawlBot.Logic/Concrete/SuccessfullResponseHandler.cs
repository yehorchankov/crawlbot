using CrawlBot.Logic.Abstract;
using CrawlBot.Logic.Models;

namespace CrawlBot.Logic.Concrete
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
