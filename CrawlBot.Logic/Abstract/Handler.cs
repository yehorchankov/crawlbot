using CrawlBot.Logic.Models;

namespace CrawlBot.Logic.Abstract
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
