using System.Threading.Tasks;

namespace EchoServer.BL.Abstraction
{
    public interface IStreamWriterAsync 
    {
        Task Write(byte[] data);
    }
}
