using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Common.Interfaces
{
    [ServiceContract]
    public interface IMaster
    {
        [OperationContract(IsOneWay = true)]
        void Call(string ClientName);

        [OperationContract(IsOneWay = true)]
        void InitializeChannel();
    }
}
