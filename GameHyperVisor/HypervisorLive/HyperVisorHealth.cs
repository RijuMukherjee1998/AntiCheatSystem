using System;
using System.Diagnostics;
using GameHyperVisor.Networking;
using System.Net.Sockets;

namespace GameHyperVisor.HypervisorLive
{
    class HyperVisorHealth
    {
        
        private int GetHypervisorPID()
        {
            return Process.GetCurrentProcess().Id;
        }

        private string SendHypervisorDataToServer(string serverIp, Int32 port, string message, ref TcpClient gameClient, ref NetworkStream networkStream)
        {
            string response = "";
            HypervisorTcp hTcp = new HypervisorTcp();
            
            hTcp.ConnectToServer(serverIp, port, ref gameClient);
            hTcp.SendDatatoServer(ref gameClient, message, ref networkStream);
            response = hTcp.ReceiveDataFromServer(ref gameClient, ref networkStream);
            hTcp.DisconnectFromServer(ref gameClient, ref networkStream);
            return response;
        }

        public void SendHypervisorDiagnostics(string serverIp, Int32 port)
        {
            string message = GetHypervisorPID().ToString();
            TcpClient gameCient = null;
            NetworkStream networkStream = null;
            Console.WriteLine(SendHypervisorDataToServer(serverIp, port, message, ref gameCient, ref networkStream));
        }

    }
}
