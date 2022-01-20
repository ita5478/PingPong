using System.Threading.Tasks;

namespace EchoServer.BL.Abstraction
{
    public interface IClientListener
    {
        void Bind(int port);

        Task ListenForClients();
    }
}
