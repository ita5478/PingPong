using Client.BL.Abstraction.IO;
using Client.BL.Abstraction;
using System.Net;
using System.Net.Sockets;
using System;

namespace Client.BL.Implementation
{
    public class ClientRunner
    {
        protected ClientSocketBase ClientSocket;
        protected IWriter<string> Writer;
        protected IReader<string> Reader;
        protected IConverter<string, byte[]> StringToByteConverter;
        protected IConverter<string, IPAddress> StringToIPConverter;
        protected IConnectionInitializer ConnectionInitializer;

        public ClientRunner(ClientSocketBase socket,
            IWriter<string> writer,
            IReader<string> reader,
            IConverter<string, byte[]> stringToByteConverter,
            IConverter<string, IPAddress> stringToIPConverter,
            IConnectionInitializer connectionInitializer)
        {
            ClientSocket = socket;
            Writer = writer;
            Reader = reader;
            StringToByteConverter = stringToByteConverter;
            StringToIPConverter = stringToIPConverter;
            ConnectionInitializer = connectionInitializer;
        }

        public void Start(string ip, int port)
        {
            try
            {
                if (!ConnectionInitializer.Connect(StringToIPConverter.ConvertTo(ip), port))
                {
                    return;
                }

                while (ClientSocket.IsConnected)
                {
                    string input = Reader.Read();

                    ClientSocket.SendData(StringToByteConverter.ConvertTo(input));
                    Writer.Write($"Sent {input} to the server.");
                    var data = ClientSocket.ReadData(input.Length);

                    Writer.Write(StringToByteConverter.ConvertFrom(data));
                }
            }
            catch (SocketException)
            {
                Writer.Write("There's been an error with the connection to the server.");
            }
        }
    }
}
