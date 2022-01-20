using System;
using EchoServer.BL.Abstraction;
using EchoServer.BL.Implementation;

namespace EchoServer.Startup
{
    public class Bootstrapper
    {
        public ClientListenerBase Initialize()
        {
            var factory = new ClientHandlerFactory();

            return new SocketClientListener(factory);
        }
    }
}
