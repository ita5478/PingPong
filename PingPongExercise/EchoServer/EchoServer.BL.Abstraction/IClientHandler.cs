using System.Threading.Tasks;
using System.Threading;

namespace EchoServer.BL.Abstraction
{
    public interface IClientHandler
    {
        Task HandleClient(CancellationToken token);
    }
}
