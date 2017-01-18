using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrawlBot.Console.Concrete;
using CrawlBot.Logic.Abstract;
using CrawlBot.Logic.Concrete;
using CrawlBot.Logic.Models;

namespace CrawlBot.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Count() <= 1)
            {
                Process.Start("CrawlBot.Console.exe");
            }
            new Program().Run();

            
        }

        public void Run()
        {
            System.Console.WriteLine("Starting the crawler net");

            var peer = new Peer("Peer(" + Guid.NewGuid() + ")");
            var peerThread = new Thread(peer.Run) { IsBackground = true };
            peerThread.Start();

            //wait for the server to start up.
            Thread.Sleep(1000);

            System.Console.WriteLine(">> Welcome, please enter the site's URI!");
            System.Console.Write(">> ");

            var startUri = System.Console.ReadLine();
            HttpContext context = new HttpContext(startUri);

            Handler successHandler = new SuccessfullResponseHandler();
            Handler failureHandler = new ResponseFailureHandler();
            successHandler.SetNextHandler(failureHandler);

            ChangedContextItemRepository repository = new ChangedContextItemRepository();
            repository.Add(context.GetLastChangedContextItem());
            try
            {
                successHandler.HandleRequest(context);
            }
            catch (Exception exc)
            {
                context.Recover(repository.GetLastChangedContextItem());
                System.Console.WriteLine(exc.Message);
                return;
            }

            peer.Channel.Ping(peer.Id, "Site proceeded");

            ProcessingQueue.Queue.Enqueue(context);
            HtmlParser parser = new HtmlParser();
            parser.ConfigureFilters("wiki", "en");
            parser.Parse();
            System.Console.ReadKey();

            peer.Stop();
            peerThread.Join();
        }
    }
}
