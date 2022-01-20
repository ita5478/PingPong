using Client.BL.Abstraction.IO;
using Client.BL.Abstraction;
using System.Net;

namespace Client.BL
{
    public class Client
    {
        protected ClientSocketBase ClientSocket;
        protected IWriter<string> Writer;
        protected IReader<string> Reader;

        public Client (ClientSocketBase socket, 
            IWriter<string> writer, 
            IReader<string> reader)
	    {
            ClientSocket = socket;
            Writer = writer;
            Reader = reader;
	    }

        public void Start(string ip, int port)
        {
            try
            {
                IPAddress address = IPAddress.Parse(ip);
                ClientSocket.Connect(address, port);
                Writer.Write($"Connected Succussfully to {ip}:{port}");

                while (ClientSocket.IsConnected)
                {
                    Writer.Write("Enter the input you want to send to the server.");
                    string input = Reader.Read();

                    ClientSocket.SendData()
                }
            }
        }
    }
}
