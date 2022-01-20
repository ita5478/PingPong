using System.Threading.Tasks;

namespace EchoServer.BL.Abstraction
{
    public interface IStreamReaderAsync
    {
        Task<byte[]> ReadAsync();
    }
}
