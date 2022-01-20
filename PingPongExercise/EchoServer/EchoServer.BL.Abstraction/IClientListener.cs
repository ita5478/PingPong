using System.Threading.Tasks;
using System.Threading;

namespace EchoServer.BL.Abstraction
{
    public interface IClientListener
    {
        void Bind(int port);

        Task ListenForClients(CancellationToken token);
    }
}
