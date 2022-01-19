using System.Threading.Tasks;

namespace Client.BL.Abstraction
{
    public abstract class ClientBase
    {
        public bool IsConnected { get; private set; }

        public abstract bool Connect();

        public abstract void Disconnect();

        public abstract void SendData(byte[] data);

        public abstract byte[] ReadData();

    }
}
