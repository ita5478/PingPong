using System.Net;

namespace Client.BL.Abstraction
{
    public abstract class ClientBase
    {
        public bool IsConnected { get; private set; }

        public abstract bool Connect(IPAddress address, int port);

        public abstract void Disconnect();

        public abstract void SendData(byte[] data);

        public abstract byte[] ReadData(int bufferSize);

    }
}
