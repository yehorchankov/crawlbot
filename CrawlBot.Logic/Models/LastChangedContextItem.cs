using System;
using CrawlBot.Logic.Abstract;

namespace CrawlBot.Logic.Models
{
    public class LastChangedContextItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime ModificationDate { get; set; }
        public Exception InnerException { get; set; }
        public DateTime InvocationTime { get; set; }

        public void Save(ContextBase context)
        {
            Id = context.Id;
            ModificationDate = DateTime.Now;
            InnerException = context.Response.InnerException;
            InvocationTime = context.Response.InvocationTime;
        }

        public void Save(HttpResponse response)
        {
            Id = response.Id;
            ModificationDate = DateTime.Now;
            InnerException = response.InnerException;
            InvocationTime = response.InvocationTime;
        }
    }
}
