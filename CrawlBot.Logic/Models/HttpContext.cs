using System;
using System.Collections.Generic;
using System.Linq;
using CrawlBot.Logic.Abstract;

namespace CrawlBot.Logic.Models
{
    public class HttpContext : ContextBase
    {
        public HttpContext(string uri) : base(new Uri(uri))
        {
        }

        public List<ContextBase> ChildContext { get; set; }

        public void AddChildContext(ContextBase context)
        {
            ChildContext.Add(context);
        }

        public void CallChildRequestRecursively()
        {
            foreach (var context in ChildContext)
            {
                var httpContext = context as HttpContext;
                if (httpContext != null)
                {
                    httpContext.CallGetRequestAsync();
                    httpContext.CallChildRequestRecursively();
                }
                else if (context is HttpClosedContext)
                {
                    context.CallGetRequestAsync();
                }
            }
        }

        public ContextBase GetChildContext(Guid id)
        {
            return ChildContext.FirstOrDefault(i => i.Id == id);
        }
    }
}
