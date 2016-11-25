using System.Net.Http;

namespace CrawlBot.Core.Abstract
{
    public abstract class ResponseContent
    {
        public ResponseContent(HttpResponseMessage response)
        {
            ResponseMessage = response;
        }

        protected HttpResponseMessage ResponseMessage;
        protected int length;

        public int Length { get { return length; } }
        
        public abstract string GetContent();
    }
}
