using EchoServer.BL.Implementation;
using EchoServer.UI;
using Server.Core.BL.Abstractions;
using Server.Core.BL.TcpSocketImplementation;

namespace EchoServer.Startup
{
    public class Bootstrapper
    {
        public ClientListenerBase Initialize()
        {
            var writer = new ConsoleWriter();
            var factory = new ClientHandlerFactory(writer);

            return new TcpSocketClientListener(factory, writer);
        }
    }
}
