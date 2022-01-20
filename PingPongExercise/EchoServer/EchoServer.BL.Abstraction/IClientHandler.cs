using System.Threading.Tasks;

namespace EchoServer.BL.Abstraction
{
    public interface IClientHandler
    {
        Task HandleClient();
    }
}
