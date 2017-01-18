using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrawlBot.Console.Abstract;

namespace CrawlBot.Console.Concrete
{
    public class Peer
    {
        public string Id { get; private set; }

        public IPing Channel;
        public IPing Host;

        public Peer(string id)
        {
            Id = id;
        }

        public void StartService()
        {
#pragma warning disable 618
            var binding = new NetPeerTcpBinding
#pragma warning restore 618
            {
                Security =
                {
                    Mode = SecurityMode.None
                }
            };

            var endpoint = new ServiceEndpoint(
                ContractDescription.GetContract(typeof(IPing)),
                binding,
                new EndpointAddress("net.p2p://SimpleP2P"));

            Host = new PingImplementation();

            _factory = new DuplexChannelFactory<IPing>(
                new InstanceContext(Host),
                endpoint);

            var channel = _factory.CreateChannel();

            ((ICommunicationObject)channel).Open();

            // wait until after the channel is open to allow access.
            Channel = channel;
        }

        private DuplexChannelFactory<IPing> _factory;

        public void StopService()
        {
            ((ICommunicationObject)Channel).Close();
            if (_factory != null)
                _factory.Close();
        }

        private readonly AutoResetEvent _stopFlag = new AutoResetEvent(false);

        public void Run()
        {
            System.Console.WriteLine("[ Starting Service ]");
            StartService();

            System.Console.WriteLine("[ Service Started ]");
            _stopFlag.WaitOne();

            System.Console.WriteLine("[ Stopping Service ]");
            StopService();

            System.Console.WriteLine("[ Service Stopped ]");
        }

        public void Stop()
        {
            _stopFlag.Set();
        }
    }
    }
