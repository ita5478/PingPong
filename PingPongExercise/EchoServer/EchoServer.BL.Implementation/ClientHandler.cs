using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using EchoServer.BL.Abstraction;

namespace EchoServer.BL.Implementation
{
    public class ClientHandler : IClientHandler
    {
        private IStreamReaderAsync _clientStreamReader;
        private IStreamWriterAsync _clientStreamWriter;

        public async Task HandleClient()
        {
            var data = await _clientStreamReader.ReadAsync();
            await _clientStreamWriter.Write(data);
        }
    }
}
