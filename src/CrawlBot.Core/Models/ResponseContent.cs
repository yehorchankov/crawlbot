using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrawlBot.Core.Models
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
