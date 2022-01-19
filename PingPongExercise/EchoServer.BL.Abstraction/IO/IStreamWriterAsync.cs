using System.Threading.Tasks;

namespace EchoServer.BL.Abstraction
{
    public interface IStreamWriterAsync <in T>
    {
        Task Write(T data);
    }
}
