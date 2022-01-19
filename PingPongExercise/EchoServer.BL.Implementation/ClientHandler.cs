using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using EchoServer.BL.Abstraction;
using Common.Abstractions;

namespace EchoServer.BL.Implementation
{
    public class ClientHandler : IClientHandler
    {
        private IStreamReaderAsync<object> _clientStreamReader;
        private IStreamWriterAsync<object> _clientStreamWriter;

        public async Task HandleClient()
        {
            var data = await _clientStreamReader.ReadAsync();
            await _clientStreamWriter.Write(data);
        }
    }
}
