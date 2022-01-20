using Client.BL.Abstraction;
using System.Net;
using System.Net.Sockets;

namespace Client.BL.Implementation
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
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        public override void Disconnect()
        {
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
