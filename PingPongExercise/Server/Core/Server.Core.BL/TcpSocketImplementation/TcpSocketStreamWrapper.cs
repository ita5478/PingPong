using Server.Core.BL.Abstractions;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server.Core.BL.TcpSocketImplementation
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
            int amountReceived = await _socketStream.ReadAsync(bytes, 0, bufferSize);
            var ret = new byte[amountReceived];
            System.Array.Copy(bytes, ret, amountReceived);
            return ret;
        }

        public async Task WriteAsync(byte[] buffer)
        {
            await _socketStream.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
