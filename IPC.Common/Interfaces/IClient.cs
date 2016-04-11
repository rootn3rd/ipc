using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Common.Interfaces
{
    public interface IClient
    {
        void ConnectToChannel(string clientName);

        void InvokeServerMethod();
    }
}
