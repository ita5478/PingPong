using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using EchoServer.BL.Abstraction;

namespace EchoServer.BL.Implementation
{
    public class SocketClientListener : ClientListenerBase
    {

        private Socket _listener;

        public SocketClientListener(IClientHandlerFactory factory) : base(factory)
        {
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public override void Bind(int port)
        {
            _listener.Bind(new IPEndPoint(IPAddress.Parse("0.0.0.0"), port));
            _listener.Listen(100);
        }

        public override void ListenForClients()
        {
            while (true)
            {
                var socketStream = new SocketStreamWrapper(_listener.Accept());

                var handler = ClientHandlerFactory.Create(socketStream);
                Task.Run(handler.HandleClient);
            }
        }
    }
}
