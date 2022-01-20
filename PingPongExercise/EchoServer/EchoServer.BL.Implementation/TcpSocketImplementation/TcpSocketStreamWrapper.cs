using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using EchoServer.BL.Abstraction.SocketWrappers;

namespace EchoServer.BL.Implementation
{
    public class TcpSocketStreamWrapper : ISocketStreamWrapper
    {
        private NetworkStream _socketStream;

        public TcpSocketStreamWrapper(NetworkStream networkStream)
        {
            _socketStream = networkStream;
        }

        public void Close()
        {
            _socketStream.Close();
            TcpClient client = new TcpClient();
        }

        public async Task<byte[]> ReadAsync(int bufferSize)
        {
            byte[] bytes = new byte[bufferSize];
            await _socketStream.ReadAsync(bytes, 0, bufferSize);
            return bytes;
        }

        public async Task WriteAsync(byte[] buffer)
        {
            await _socketStream.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
