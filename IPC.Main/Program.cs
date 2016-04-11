using IPC.Client;
using IPC.Common.Interfaces;
using IPC.Common.Services;

using IPC.Master;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer unityContainer = new UnityContainer();

            unityContainer.RegisterType<IMaster, MasterService>();

            //singleton master
            var masterInstance = unityContainer.Resolve<IMaster>();
            unityContainer.RegisterInstance(masterInstance, new ContainerControlledLifetimeManager());


            //singleton client
            unityContainer.RegisterType<IClient, ClientService>();
            var clientInstance = unityContainer.Resolve<IClient>();
            unityContainer.RegisterInstance(clientInstance, new ContainerControlledLifetimeManager());


            //singleton process service
            unityContainer.RegisterType<IProcessService, ProcessService>();
            var processServiceInstance = unityContainer.Resolve<IProcessService>();
            unityContainer.RegisterInstance(processServiceInstance, new ContainerControlledLifetimeManager());


            //checking the command line arguments
            if (args.Length == 0)
            {
                //host the service
                var masterService = unityContainer.Resolve<IMaster>();

                masterService.InitializeChannel();
                Console.WriteLine("MasterService running. Press Return to Exit");

                //spawn the clients
                var processService = unityContainer.Resolve<IProcessService>();
                processService.StartProcess();
                
                //wait for the clients to connect
                Console.ReadLine();

            }
            else
            {
                //treat as client
                var client = unityContainer.Resolve<IClient>();
                
                //connect to service
                client.ConnectToChannel(args[0]);
                
                //call methods
                client.InvokeServerMethod();

                Console.WriteLine("*******Client Ended***********");
                Console.ReadLine();



            }


        }
    }
}
