using System;
using System.Net;
using System.Net.Sockets;

namespace Chia_Cloud_Mining_AutoPayment_V2.ServerSocketLib
{
    public class ServerSocket_test
    {
        private readonly int ServerPort;
        private Socket serverSocket;

        public ServerSocket_test(int serverPort)
        {
            ServerPort = serverPort;
            serverSocket = Build();
        }

        private Socket Build()
        {
            IPAddress ipAddress = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, ServerPort);

            var socket = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(localEndPoint);
            //socket.Listen();

            Console.WriteLine($"Server Start: Port {ServerPort}");
            return socket;
        }

        public void Run()
        {
            try
            {
                Socket acceptSocket = serverSocket.Accept();

                var remoteAddress = ((IPEndPoint)acceptSocket.RemoteEndPoint).Address.ToString();
                var remotePort = ((IPEndPoint)acceptSocket.RemoteEndPoint).Port;
                Console.WriteLine($"Nuovo Client Connesso ->{remoteAddress} : {remotePort}");

                // fai qualcosa
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"Errpr -> {ex.Message}");
            }
            finally
            {
                if (serverSocket.Connected)
                {
                    serverSocket.Shutdown(SocketShutdown.Both);
                    serverSocket.Close();
                }
            }
        }
    }
}
