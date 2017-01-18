using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlBot.Logic.Models;

namespace CrawlBot.Logic.Abstract
{
    public abstract class ContextBase
    {

        public HttpRequest Request { get; }
        public HttpResponse Response { get; }

        public Guid Id { get; set; } = Guid.NewGuid();

        public ContextBase(Uri uri)
        {
            Request = new HttpRequest(uri);
            Response = new HttpResponse(uri);
        }

        public bool CallGetRequestAsync()
        {
            return Response.Call();
        }

        public LastChangedContextItem GetLastChangedContextItem()
        {
            var item = new LastChangedContextItem();
            item.Save(this);
            return item;
        }

        public void Recover(LastChangedContextItem item)
        {
            SetFieldsValues(item);
        }

        public void SetFieldsValues(LastChangedContextItem item)
        {
            Response.InnerException = item.InnerException;
            Response.InvocationTime = item.InvocationTime;
        }
    }
}
