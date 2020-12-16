using EasySaveClient.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace EasySaveClient.Networking
{
    public class ClientSocket 
    {
        private Socket _socket;
        private byte[] _buffer;
        private PacketHandler ph;
        public List<Thread> threadDataList;
        public ClientSocket()
        {
            Console.WriteLine("[+] Initializing the socket");
            _socket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );
            threadDataList = new List<Thread>();
            ph = PacketHandler.Instance;
        }

        public void Connect(string ipAddress, int PORT)
        {
            Console.WriteLine("[+] Trying to connect to {0} in the port number {1}", ipAddress, PORT);
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), PORT), ConnectCallBack, null);
        }

        public void ConnectCallBack(IAsyncResult resultConnection)
        {
            if (_socket.Connected)
            {
                Console.WriteLine("[+] Connected to the server !");
                _buffer = new byte[1024];
                _socket.BeginReceive(
                    _buffer,
                    0,
                    _buffer.Length,
                    SocketFlags.None,
                    ReceiveCallBack,
                    null
                    );

            }
            else
            {
                Console.Write("[-] Could not connect to the server...");
            }
        }

        public void ReceiveCallBack(IAsyncResult resultConnection)
        {
            Socket clientSocket = (Socket)resultConnection.AsyncState;
            try
            {
                Thread threadDataElement = new Thread(new ThreadStart( () => {
                    int bufferLength = _socket.EndReceive(resultConnection);
                    byte[] packet = new byte[bufferLength];
                    Buffer.BlockCopy(_buffer, 0, packet, 0, packet.Length);
                    ph.Handle(packet,
                        clientSocket);
                }));
                threadDataList.Add(threadDataElement);
                threadDataElement.Start();

            }
            catch (SocketException e)
            {
                Console.WriteLine("[-] Connexion had to be closed because the host ended the connection...");
                System.Environment.Exit(0);
            }

            _buffer = new byte[1024];
            _socket.BeginReceive(
                _buffer,
                0,
                _buffer.Length,
                SocketFlags.None,
                ReceiveCallBack,
                null
                );
        }

        public void Send(byte[] data)
        {
            _socket.Send(data);
        }

       
    }
}
