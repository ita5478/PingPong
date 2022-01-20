using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;
using EchoServer.BL.Abstraction.SocketWrappers;


namespace EchoServer.BL.Implementation
{
    public class SocketStreamWrapper : ISocketStreamWrapper
    {
        private const int INTERVAL = 100;
        private Socket _socket;

        public SocketStreamWrapper(Socket socket)
        {
            _socket = socket;
        }

        public void Close()
        {
            _socket.Close();
        }

        public async Task<byte[]> ReadAsync(int bufferSize)
        {
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.SetBuffer(new byte[bufferSize], 0, bufferSize);
            while (_socket.ReceiveAsync(args))
            {
                await Task.Delay(INTERVAL);
            }

            return args.Buffer;
        }

        public async Task WriteAsync(byte[] buffer)
        {
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.SetBuffer(buffer);

            while (_socket.SendAsync(args))
            {
                await Task.Delay(INTERVAL);
            }
        }
    }
}
