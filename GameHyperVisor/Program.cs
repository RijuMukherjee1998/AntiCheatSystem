using System;
using System.Threading;
using GameHyperVisor.ProcessMonitor;
using GameHyperVisor.HypervisorLive;
namespace GameHyperVisor
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGameHypervisor();
        }

        //Tested with a test server listner
        public static void TestGameHypervisor()
        {
            ProcessList processList = new ProcessList();
            HyperVisorHealth hyperVisorHealth = new HyperVisorHealth();
            System.Net.IPAddress localAddr = System.Net.IPAddress.Parse("127.0.0.1");
            Int32 port = 8080;

            while (true)
            {
                string[] prohibitedProcesses = { "msedge" };
                hyperVisorHealth.SendHypervisorDiagnostics(localAddr.ToString(), port);
                processList.StopProhibitedProcessesByProcessName(prohibitedProcesses);
                Thread.Sleep(1000);
            }
        }
    }
}
