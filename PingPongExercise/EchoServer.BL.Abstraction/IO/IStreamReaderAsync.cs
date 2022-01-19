using System.Threading.Tasks;

namespace EchoServer.BL.Abstraction
{
    public interface IStreamReaderAsync <T>
    {
        Task<T> ReadAsync();
    }
}
