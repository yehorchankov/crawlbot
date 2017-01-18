using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlBot.Console.Abstract;
using CrawlBot.Logic.Concrete;
using CrawlBot.Logic.Models;
using HtmlAgilityPack;

namespace CrawlBot.Console.Concrete
{
    public class HtmlParser : IHtmlParser
    {
        public List<string> Filters { get; set; } = new List<string>();

        public void Parse()
        {
            while (ProcessingQueue.Queue.Count > 0)
            {
                var item = ProcessingQueue.Queue.Dequeue();
                item.CallGetRequestAsync();
                var uri = item.Response.Uri.OriginalString;
                var html = String.Empty;
                if (ProcessingQueue.VisitedSites.ContainsKey(uri) &&
                    ProcessingQueue.VisitedSites[uri] < DateTime.Now.AddDays(-1) &&
                    ProcessingQueue.VisitedSites.Count < 20) //hardcoded
                {
                    html = item.Response.ResponseContent.GetContent();
                    ProcessingQueue.VisitedSites[uri] = DateTime.Now;
                }
                else if (!ProcessingQueue.VisitedSites.ContainsKey(uri))
                {
                    html = item.Response.ResponseContent.GetContent();
                    ProcessingQueue.VisitedSites.Add(uri, DateTime.Now);
                }

                Filter(uri, html);
                
                System.Console.WriteLine($"[Site {uri} was processed]");
            }
        }

        private void Filter(string uri, string html)
        {
            IHtmlSerializer serializer = new HtmlSerializer();

            var result = Filters.Aggregate(true, (current, filter) => current & html.Contains(filter));
            if (!result) return;

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            LoadToQueue(ExtractAllAHrefTags(doc), new Uri(uri));

            try
            {
                serializer.SaveOnDisk(Guid.NewGuid() + ".html", html);
            }
            catch (Exception exc)
            {
                System.Console.WriteLine(exc.Message);
            }

        }

        private List<string> ExtractAllAHrefTags(HtmlDocument htmlSnippet)
        {
            List<string> hrefTags = new List<string>();

            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                hrefTags.Add(att.Value);
            }

            return hrefTags;
        }

        private void LoadToQueue(List<string> uris, Uri baseUri)
        {
            foreach (var uri in uris.Where(u => !ProcessingQueue.VisitedSites.ContainsKey(u) || ProcessingQueue.VisitedSites[u] < DateTime.Now.AddDays(-1)))
            {
                if (uri.StartsWith("#")) return;

                var tempUri = uri;
                var http = baseUri.AbsoluteUri.StartsWith("https") ? "https://" : "http://";
                if (!uri.StartsWith("http"))
                    tempUri = $"{http}{baseUri.Host}{uri}";
                ProcessingQueue.Queue.Enqueue(new HttpContext(tempUri));   
            }
        }

        public void ConfigureFilters(params string[] filters)
        {
            Filters.AddRange(filters);
        }
    }
}
