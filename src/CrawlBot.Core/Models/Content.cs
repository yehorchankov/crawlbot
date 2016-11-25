using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrawlBot.Core.Models
{
    public class Content : ResponseContent
    {
        public Content(HttpResponseMessage response) : base(response)
        {

        }

        public override string GetContent()
        {
            var content = GetResponseText().Result;
            length = content.Length;
            return content;
        }

        private async Task<string> GetResponseText()
        {
            return await ResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
