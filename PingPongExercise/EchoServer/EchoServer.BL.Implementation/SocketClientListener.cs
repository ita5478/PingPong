using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using EchoServer.BL.Abstraction;
using EchoServer.BL.Abstraction.IO;

namespace EchoServer.BL.Implementation
{
    public class SocketClientListener : ClientListenerBase
    {

        private Socket _listener;
        private IWriter<string> _writer;

        public SocketClientListener(IClientHandlerFactory factory, IWriter<string> writer) 
            : base(factory)
        {
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _writer = writer;
        }

        public override void Bind(int port)
        {
            _listener.Bind(new IPEndPoint(IPAddress.Parse("0.0.0.0"), port));
            _listener.Listen(100);

            _writer.Write($"Listening on port {port}.");
        }

        public override void ListenForClients()
        {
            while (true)
            {
                var socketStream = new SocketStreamWrapper(_listener.Accept());
                _writer.Write("A new connection has been made.");
                var handler = ClientHandlerFactory.Create(socketStream);
                Task.Run(handler.HandleClient);
            }
        }
    }
}
