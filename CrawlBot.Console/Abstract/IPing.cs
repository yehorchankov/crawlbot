using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CrawlBot.Console.Abstract
{
    //Contract for our network. It says we can 'ping'
    [ServiceContract(CallbackContract = typeof(IPing))]
    public interface IPing
    {
        [OperationContract(IsOneWay = true)]
        void Ping(string sender, string message);
    }
}
