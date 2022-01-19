using System.Threading.Tasks;

namespace EchoServer.BL.Abstraction
{
    public interface IClientListener
    {
        Task ListenForClients();
    }
}
