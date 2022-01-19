using System.Net;
using System.Net.Sockets;
using Client.BL.Abstraction;

namespace Client.BL.Implementation
{
    class Client : ClientBase
    {
        private Socket _socket;

        

        public override bool Connect()
        {
            _socket.Connect()
        }

        public override void Disconnect()
        {
            throw new System.NotImplementedException();
        }

        public override byte[] ReadData()
        {
            throw new System.NotImplementedException();
        }

        public override void SendData(byte[] data)
        {
            throw new System.NotImplementedException();
        }
    }
}
