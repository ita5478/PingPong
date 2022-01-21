using Common.Abstractions.IO;
using EchoServer.BL.Abstraction;
using EchoServer.BL.Abstraction.SocketWrappers;

namespace EchoServer.BL.Implementation
{
    public class ClientHandlerFactory : IClientHandlerFactory
    {
        private IWriter<string> _writer;

        public ClientHandlerFactory(IWriter<string> writer)
        {
            _writer = writer;
        }

        public IClientHandler Create(ISocketStreamWrapper socketWrapper)
        {
            return new ClientHandler(socketWrapper, _writer);
        }
    }
}
