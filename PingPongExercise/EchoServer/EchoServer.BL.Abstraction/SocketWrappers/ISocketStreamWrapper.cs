using System.Threading.Tasks;

namespace EchoServer.BL.Abstraction.SocketWrappers
{
    public interface ISocketStreamWrapper
    {
        Task<byte[]> ReadAsync();

        Task WriteAsync(byte[] buffer);

        Task Close();
    }
}
