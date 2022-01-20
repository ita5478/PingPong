using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using EchoServer.BL.Abstraction.SocketWrappers;
using System.Linq;


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
            object token = new object();
            args.UserToken = token;
            args.SetBuffer(new byte[bufferSize], 0, bufferSize);

            int bytesReceived = 0;
            bool finished = false;
            args.Completed += (sender, args) =>
            {
                bytesReceived += args.BytesTransferred;
                finished = true;
            };

            _socket.ReceiveAsync(args);

            await Task.Run(async () =>
            {
                while (!finished)
                {
                    await Task.Delay(INTERVAL);
                }
            });

            byte[] bytes = new byte[bytesReceived];
            System.Array.Copy(args.Buffer, bytes, bytesReceived);
            return bytes;
        }

        public async Task WriteAsync(byte[] buffer)
        {
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.SetBuffer(buffer);
            bool finished = false;

            args.Completed += (sender, args) =>
            {
                finished = true;
            };

            var pending = _socket.SendAsync(args);
            while (pending && !finished)
            {
                await Task.Delay(INTERVAL);
            }
        }
    }
}
