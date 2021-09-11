using System;
using System.Net.Sockets;

namespace GameHyperVisor.Networking
{
    class HypervisorTcp
    {
        
        public void ConnectToServer(string serverIp, Int32 port, ref TcpClient gameClient)
        {
            if (gameClient == null)
            {
                try
                {
                    gameClient = new TcpClient(serverIp, port);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }

            }
        }

        public NetworkStream SendDatatoServer(ref TcpClient gameClient, string message, ref NetworkStream networkStream)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            
            if (gameClient != null && networkStream == null)
            {
                try
                {
                    networkStream = gameClient.GetStream();
                    networkStream.Write(data, 0, data.Length);
                    Console.WriteLine("Sent: {0}", message);
                }
                catch
                {
                    Console.WriteLine("NetworkStream not created...");
                }
            }
            return networkStream;
        }

        public String ReceiveDataFromServer(ref TcpClient gameClient, ref NetworkStream networkStream)
        {
            Byte []data = new Byte[256];
            String responseData = String.Empty;
            try
            {
                Int32 bytes = networkStream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
            }
            catch
            {
                Console.WriteLine("NetworkStream is null...");
            }
            return responseData;
        }

        public void DisconnectFromServer(ref TcpClient gameClient, ref NetworkStream networkStream)
        {
            if (gameClient != null && networkStream != null)
            {
                gameClient.Close();
                networkStream.Close();
                Console.WriteLine("Session Closed");
                gameClient = null;
                networkStream = null;
            }
            else
                Console.WriteLine("Unable to disconnect TcpClient or NetworkStream is null");

        }
    }
}





