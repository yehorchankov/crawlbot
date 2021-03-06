﻿using System;
using CrawlBot.Logic.Abstract;
using CrawlBot.Logic.Models;

namespace CrawlBot.Logic.Concrete
{
    public class ResponseFailureHandler : Handler
    {
        public override void HandleRequest(HttpContext context)
        {
            if (context.Response.InnerException != null)
            {
                Console.WriteLine("Request failed");
                //TODO: handle with Memento -> to queue again!
            }
        }
    }
}
