using System.Threading.Tasks;

namespace EchoServer.BL.Abstraction.SocketWrappers
{
    public interface ISocketStreamWrapper
    {
        Task<byte[]> ReadAsync(int bufferSize);

        Task WriteAsync(byte[] buffer);

        void Close();
    }
}
