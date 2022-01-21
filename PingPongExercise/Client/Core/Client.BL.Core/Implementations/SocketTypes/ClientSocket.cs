using Client.BL.Core.Policy.Abstraction;
using System.Net;
using System.Net.Sockets;

namespace Client.BL.Core.Implementation
{
    public class ClientSocket : ClientSocketBase
    {
        private Socket _socket;

        public ClientSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IsConnected = false;
        }

        public override bool Connect(IPAddress address, int port)
        {
            try
            {
                _socket.Connect(address, port);
            }
            catch (SocketException)
            {
                return false;
            }

            IsConnected = true;
            return true;
        }

        public override void Disconnect()
        {
            try
            {
                _socket.Disconnect(false);
                IsConnected = false;
            }
            catch (SocketException)
            {
                // output to log
            }
        }

        public override byte[] ReadData(int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];

            try
            {
                _socket.Receive(buffer);
            }
            catch (SocketException)
            {
                // output to logger
                Disconnect();
                throw;
            }

            return buffer;
        }

        public override void SendData(byte[] data)
        {
            try
            {
                _socket.Send(data);
            }
            catch (SocketException)
            {
                // output to logger
                Disconnect();
                throw;
            }
        }
    }
}
