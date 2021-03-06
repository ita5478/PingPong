using Common.Abstractions.IO;
using Server.Core.BL.Abstractions;
using System.Net;
using System.Net.Sockets;

namespace Server.Core.BL.TcpSocketImplementation
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

            _writer.Write($"Listening on port {port}.");
        }

        public override void ListenForClients()
        {
            try
            {
                _listener.Start();
            }
            catch (SocketException)
            {
                _writer.Write("There's already a server bound to this IP and port.");
                return;
            }

            System.Threading.CancellationTokenSource source = new System.Threading.CancellationTokenSource();

            while (true)
            {
                var clientStream = new TcpSocketStreamWrapper(_listener.AcceptTcpClient().GetStream());
                _writer.Write("A new connection has been made.");
                var handler = ClientHandlerFactory.Create(clientStream);
                handler.HandleClient(source.Token);
            }

        }
    }
}
