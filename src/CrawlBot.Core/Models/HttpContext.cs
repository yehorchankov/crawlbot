﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CrawlBot.Core.Abstract;
using CrawlBot.Core.Concrete;

namespace CrawlBot.Core.Models
{
    public class HttpContext
    {
        public HttpRequest Request { get; }
        public HttpResponse Response { get; }

        public Guid Id { get; set; }

        public HttpContext(string uri) : this(new Uri(uri))
        {
            
        }

        public HttpContext(Uri uri)
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

        public void Recover(ChangedContextItemRepository repository)
        {
            SetFieldsValues(repository.GetItemById(Id));
        }

        public void SetFieldsValues(LastChangedContextItem item)
        {
            Response.InnerException = item.InnerException;
            Response.InvocationTime = item.InvocationTime;
        }
    }
}
