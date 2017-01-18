using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlBot.Console.Abstract;

namespace CrawlBot.Console.Concrete
{
    //implementation of our ping class
    public class PingImplementation : IPing
    {
        public void Ping(string sender, string message)
        {
            System.Console.WriteLine($"{sender} says: {message}");
        }
    }
}
