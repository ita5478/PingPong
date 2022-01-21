using System.Net;

namespace Client.BL.Core.Policy.Abstraction
{
    public abstract class ClientSocketBase
    {
        public bool IsConnected { get; protected set; }

        public abstract bool Connect(IPAddress address, int port);

        public abstract void Disconnect();

        public abstract void SendData(byte[] data);

        public abstract byte[] ReadData(int bufferSize);

    }
}
