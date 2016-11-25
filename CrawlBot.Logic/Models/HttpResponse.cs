using System;
using System.Net;
using CrawlBot.Logic.Abstract;
using CrawlBot.Logic.Concrete;

namespace CrawlBot.Logic.Models
{
    public class HttpResponse : HttpBase
    {
        public ResponseContent ResponseContent { get; set; }

        public HttpStatusCode ResponseCode { get; set; }

        public Exception InnerException { get; set; }

        public HttpResponse(Uri uri) : base(uri)
        {
            
        }

        public bool Call()
        {
            IWebDownloader downloader = new HttpDownloader();
            try
            {
                InvocationTime = DateTime.Now;
                ResponseContent = new ContentProxy(downloader.GetHtmlContent(Uri).Result);
            }
            catch (Exception exc)
            {
                InnerException = exc;
                return false;
            }
            return true;
        }

        public LastChangedContextItem GetLastChangedContextItem()
        {
            var item = new LastChangedContextItem();
            item.Save(this);
            return item;
        }

        public void Recover(ChangedContextItemRepository repository)
        {
            SetFieldsValues(repository.GetItemById(Id));
        }

        public void SetFieldsValues(LastChangedContextItem item)
        {
            InnerException = item.InnerException;
            InvocationTime = item.InvocationTime;
        }
    }
}
