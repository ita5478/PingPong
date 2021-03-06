using Client.BL.Core.Policy.Abstraction;
using System.Net;
using System.Net.Sockets;

namespace Client.BL.Core.Implementation
{
    public class TcpClientSocket : ClientSocketBase
    {
        private TcpClient _clientSocket;
        public TcpClientSocket()
        {
            _clientSocket = new TcpClient();
        }

        public override bool Connect(IPAddress address, int port)
        {
            try
            {
                _clientSocket.Connect(new IPEndPoint(address, port));
                IsConnected = true;
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        public override void Disconnect()
        {
            IsConnected = false;
            _clientSocket.Close();
        }

        public override byte[] ReadData(int bufferSize)
        {
            try
            {
                byte[] bytes = new byte[bufferSize];
                _clientSocket.GetStream().Read(bytes, 0, bufferSize);
                return bytes;
            }
            catch (SocketException)
            {
                Disconnect();
                throw;
            }
        }

        public override void SendData(byte[] data)
        {
            try
            {
                _clientSocket.GetStream().Write(data);
            }
            catch (SocketException)
            {
                Disconnect();
                throw;
            }
        }
    }
}
