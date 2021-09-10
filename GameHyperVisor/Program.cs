using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using GameHyperVisor.ProcessMonitor;
namespace GameHyperVisor
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessList processList = new ProcessList();

            while (true)
            {
                string[] prohibitedProcesses = {"msedge"};
                processList.StopProhibitedProcessesByProcessName(prohibitedProcesses);
                System.Threading.Thread.Sleep(1000);
            }
            
        }
    }
}
