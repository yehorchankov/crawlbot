using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CrawlBot.Core.Abstract;
using CrawlBot.Core.Concrete;

namespace CrawlBot.Core.Models
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
