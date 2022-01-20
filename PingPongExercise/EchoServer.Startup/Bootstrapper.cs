using System;
using EchoServer.BL.Abstraction;
using EchoServer.BL.Implementation;

namespace EchoServer.Startup
{
    public class Bootstrapper
    {
        public ClientListenerBase Initialize()
        {
            var writer = new ConsoleWriter();
            var factory = new ClientHandlerFactory(writer);

            return new SocketClientListener(factory, writer);
        }
    }
}
