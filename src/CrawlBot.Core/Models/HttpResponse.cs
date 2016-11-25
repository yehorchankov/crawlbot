﻿using System;
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
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
