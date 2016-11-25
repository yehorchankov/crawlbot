using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CrawlBot.Core.Abstract;

namespace CrawlBot.Core.Models
{
    public class ContentProxy : ResponseContent
    {
        private readonly ResponseContent _content;

        public ContentProxy(HttpResponseMessage response) : base(response)
        {
            _content = new Content(response);
        }

        public override string GetContent()
        {
            string result = String.Empty;
            if (ResponseMessage != null && ResponseMessage.IsSuccessStatusCode)
            {
                result = _content.GetContent();
            }
            return result;
        }
    }
}
