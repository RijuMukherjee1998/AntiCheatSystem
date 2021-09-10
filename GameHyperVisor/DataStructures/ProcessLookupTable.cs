using System;
using System.Collections.Generic;

namespace GameHyperVisor.DataStructures
{
    class ProcessLookupTable
    {
        public void AddProcessToDictionary(string processId, string processName, ref Dictionary<string, string> processDictionary)
        {
            if (processDictionary != null)
                processDictionary.Add(processId, processName);
            else
                Console.WriteLine("ERR: ProcessDictionary is NULL");
        }
        
        public void DeleteProcessFromDictionary(string processId, ref Dictionary<string, string> processDictionary)
        {

            if (processDictionary != null && processDictionary.Remove(processId) == false)
                Console.WriteLine("ERR: Process Dictionary dosen't have that process");
        }

        public void UpdateProcessInDictionary(string processId, string processName, ref Dictionary<string, string> processDictionary)
        {
            if (processDictionary == null)
            {
                Console.WriteLine("ERR: ProcessDictionary is NULL");
                return;
            }

            if (processDictionary.Remove(processId) == true)
            {
                processDictionary.Add(processId, processName);
            }
            else
                Console.WriteLine("No such Process exists");

        }

        public bool DoesProcessExist(string processId, ref Dictionary<string, string> processDictionary)
        {
            return processDictionary.ContainsKey(processId);
        }

        public void ClearProcessDictionary(ref Dictionary<string, string> processDictionary)
        {
            if (processDictionary == null)
                return;
            processDictionary.Clear();
        }

        public void ListAllKeyValuePairs(ref Dictionary<string, string> processDictionary)
        {
            if (processDictionary == null)
                return;
            foreach(var process in processDictionary)
            {
                Console.WriteLine(process.Value + " => " + process.Key);
            }
        }
    }
}
