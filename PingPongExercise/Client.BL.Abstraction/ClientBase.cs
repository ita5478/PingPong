using System.Threading.Tasks;

namespace Client.BL.Abstraction
{
    public abstract class ClientBase
    {
        public bool IsConnected { get; private set; }

        public abstract Task<bool> Connect();

        public abstract Task Disconnect();

        public abstract Task SendData(byte[] data);

        public abstract Task<byte[]> ReadData();

    }
}
