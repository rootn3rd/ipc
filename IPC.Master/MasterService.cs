using IPC.Common;
using IPC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPC.Master
{
                
    [ServiceBehavior(ConcurrencyMode= ConcurrencyMode.Multiple, InstanceContextMode =InstanceContextMode.Single)]
    public class MasterService : IMaster
    {
        public int i;

        public void Call(string ClientName)
        {
            // increment instance counts
            i++;

            // display client name, instance number , thread number and time when 
            // the method was called

            Console.WriteLine("Client name :" + ClientName + " Instance:" +
              i.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() +
              " Time:" + DateTime.Now.ToString() + "\n\n");

            // Wait for 5 seconds
            Thread.Sleep(500);
        }

        public void InitializeChannel()
        {
            string address = Constants.EndPointAddress;

            ServiceHost serviceHost = new ServiceHost(typeof(MasterService));
            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            serviceHost.AddServiceEndpoint(typeof(IMaster), binding, address);
            serviceHost.Open();
        }
    }
}
