using IPC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Common.Services
{
    public class ProcessService : IProcessService
    {

        public void StartProcess()
        {
            var childProcessStartInfo = new ProcessStartInfo();
            var fileName = Process.GetCurrentProcess().MainModule.FileName.Replace(".vshost", "");
            childProcessStartInfo.FileName = fileName;
            childProcessStartInfo.Arguments = "Child1";
            Process.Start(childProcessStartInfo);

        }
    }
}
