using System;
using System.Diagnostics;
using GameHyperVisor.DataStructures;
using System.Collections.Generic;
using System.Management;
namespace GameHyperVisor.ProcessMonitor
{
    class ProcessList
    {
        private static Dictionary<string, string> processDictionary = new Dictionary<string, string>();

        private void GetUpdatedProcessList(ref ProcessLookupTable pd)
        {
            Process[] processCollection = Process.GetProcesses();
            pd.ClearProcessDictionary(ref processDictionary);
            foreach (var process in processCollection)
            {
                pd.AddProcessToDictionary(process.Id.ToString(), process.ProcessName, ref processDictionary);   
            }
        }

        public void StopProhibitedProcessesByProcessId(string []prohibitedProcessId)
        {
            ProcessLookupTable pd = new ProcessLookupTable();
            GetUpdatedProcessList(ref pd);
            
            foreach (string processId in prohibitedProcessId)
            {
                if (pd.DoesProcessExist(processId, ref processDictionary) == true)
                {
                    Process currentProcess = Process.GetProcessById(Int32.Parse(processId));
                    currentProcess.Kill();
                    pd.DeleteProcessFromDictionary(processId, ref processDictionary);
                }
            }
            pd.ListAllKeyValuePairs(ref processDictionary);
        }

        public void StopProhibitedProcessesByProcessName(string[] prohibitedProcessName)
        {
            ProcessLookupTable pd = new ProcessLookupTable();
            GetUpdatedProcessList(ref pd);

            foreach (string processName in prohibitedProcessName)
            {
                Process[] currentProcesses = Process.GetProcessesByName(processName);
                foreach (Process currentProcess in currentProcesses)
                {
                    if (pd.DoesProcessExist(currentProcess.Id.ToString(), ref processDictionary) == true)
                    {
                        currentProcess.Kill();
                        pd.DeleteProcessFromDictionary(currentProcess.Id.ToString(), ref processDictionary);
                    }
                }
            }
            pd.ListAllKeyValuePairs(ref processDictionary);
        }

    }
}
