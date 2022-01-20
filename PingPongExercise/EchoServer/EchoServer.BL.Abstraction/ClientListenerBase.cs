using System.Threading.Tasks;
using System.Threading;

namespace EchoServer.BL.Abstraction
{
    public abstract class ClientListenerBase
    {
        protected IClientHandlerFactory ClientHandlerFactory;

        public ClientListenerBase(IClientHandlerFactory factory)
        {
            ClientHandlerFactory = factory;
        }

        public abstract void Bind(int port);

        public abstract void ListenForClients();
    }
}
