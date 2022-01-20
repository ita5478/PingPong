using EchoServer.BL.Abstraction;
using EchoServer.BL.Abstraction.SocketWrappers;

namespace EchoServer.BL.Implementation
{
    public class ClientHandlerFactory : IClientHandlerFactory
    {
        public IClientHandler Create(ISocketStreamWrapper socketWrapper)
        {
            return new ClientHandler(socketWrapper);
        }
    }
}
