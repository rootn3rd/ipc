using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IPC.Common.Interfaces;
using System.ServiceModel;
using IPC.Common;

namespace IPC.Client
{
    public class ClientService : IClient
    {
        private IMaster _connection;
        private string _clientName;

        public void ConnectToChannel(string clientName)
        {
            _clientName = clientName;

            string address = Constants.EndPointAddress;

            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            EndpointAddress ep = new EndpointAddress(address);
            _connection = ChannelFactory<IMaster>.CreateChannel(binding, ep);

            Console.WriteLine("Client Connected");

        }

        public void InvokeServerMethod()
        {
            if (_connection == null)
                throw new ApplicationException("Host is either down or the client is not able to connect");


            for (int i = 0; i < 5; i++)
            {
                _connection.Call(_clientName);
            }

            Console.ReadLine();

        }
    }
}
