using System.Net.Http;
using System.Threading.Tasks;
using CrawlBot.Logic.Abstract;

namespace CrawlBot.Logic.Models
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
