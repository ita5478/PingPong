using System.Threading.Tasks;

namespace Server.Core.BL.Abstractions
{
    public interface ISocketStreamWrapper
    {
        Task<byte[]> ReadAsync(int bufferSize);

        Task WriteAsync(byte[] buffer);

        void Close();
    }
}
