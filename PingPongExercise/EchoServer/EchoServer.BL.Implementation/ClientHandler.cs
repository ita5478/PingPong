using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using EchoServer.BL.Abstraction;
using EchoServer.BL.Abstraction.SocketWrappers;

namespace EchoServer.BL.Implementation
{
    public class ClientHandler : IClientHandler
    {
        private ISocketStreamWrapper _socketStream;

        public ClientHandler(ISocketStreamWrapper stream)
        {
            _socketStream = stream;
        }

        public async Task HandleClient()
        {
            try
            {
                var data = await _socketStream.ReadAsync(1000);
                await _socketStream.WriteAsync(data);
            }
            catch (SocketException)
            {
                _socketStream.Close();
            }
        }
    }
}
