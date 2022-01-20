using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using EchoServer.BL.Abstraction;
using EchoServer.BL.Abstraction.SocketWrappers;
using EchoServer.BL.Abstraction.IO;
using System.Threading;

namespace EchoServer.BL.Implementation
{
    public class ClientHandler : IClientHandler
    {
        private ISocketStreamWrapper _socketStream;
        private IWriter<string> _writer;
        public ClientHandler(ISocketStreamWrapper stream, IWriter<string> writer)
        {
            _socketStream = stream;
            _writer = writer;
        }

        public async Task HandleClient(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    _writer.Write("Waiting for the client to send a message.");
                    var data = await _socketStream.ReadAsync(100);
                    _writer.Write("Received bytes. Sending them back to the client.");
                    await _socketStream.WriteAsync(data);
                    _writer.Write("Succussfuly sent the data back to the client.");
                }
                catch (SocketException)
                {
                    _writer.Write("Socket isn't responding. Closing connection.");
                    _socketStream.Close();
                }
            }
        }
    }
}
