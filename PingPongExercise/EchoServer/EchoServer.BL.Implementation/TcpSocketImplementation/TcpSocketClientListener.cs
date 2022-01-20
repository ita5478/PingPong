using EchoServer.BL.Abstraction;
using EchoServer.BL.Abstraction.IO;
using System.Net;
using System.Net.Sockets;

namespace EchoServer.BL.Implementation
{
    public class TcpSocketClientListener : ClientListenerBase
    {
        private IWriter<string> _writer;
        private TcpListener _listener;

        public TcpSocketClientListener(IClientHandlerFactory factory, IWriter<string> writer) 
            : base(factory)
        {
            _writer = writer;
        }

        public override void Bind(int port)
        {
            _listener = new TcpListener(IPAddress.Parse("0.0.0.0"), port);
        }

        public override void ListenForClients()
        {
            _listener.Start();
            System.Threading.CancellationTokenSource source = new System.Threading.CancellationTokenSource();

            while (true)
            {
                var clientStream = new TcpSocketStreamWrapper(_listener.AcceptTcpClient().GetStream());
                var handler = ClientHandlerFactory.Create(clientStream);
                handler.HandleClient(source.Token);
            }

        }
    }
}
