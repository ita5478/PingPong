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
        protected IConverter<string, byte[]> Converter;

        public ClientRunner(ClientSocketBase socket,
            IWriter<string> writer,
            IReader<string> reader,
            IConverter<string, byte[]> converter)
        {
            ClientSocket = socket;
            Writer = writer;
            Reader = reader;
            Converter = converter;
        }

        public void Start(string ip, int port)
        {
            try
            {
                if (!Connect(ip, port))
                {
                    return;
                }

                while (ClientSocket.IsConnected)
                {
                    string input = Reader.Read();

                    ClientSocket.SendData(Converter.ConvertTo(input));
                    Writer.Write($"Sent {input} to the server.");
                    var data = ClientSocket.ReadData(input.Length);

                    Writer.Write(Converter.ConvertFrom(data));
                }
            }
            catch (SocketException)
            {
                Writer.Write("There's been an error with the connection to the server.");
            }
        }

        private bool Connect(string ip, int port)
        {
            try
            {
                IPAddress address = IPAddress.Parse(ip);
                var connectionStatus = ClientSocket.Connect(address, port);
                if (connectionStatus)
                {
                    Writer.Write($"Connected Succussfully to {ip}:{port}");
                }
                else
                {
                    Writer.Write($"Connection to {ip}:{port} failed.");
                }

                return connectionStatus;
            }
            catch (FormatException)
            {
                Writer.Write("Invalid IP format entered.");
                return false;
            }
            catch (ArgumentNullException)
            {
                Writer.Write("No IP entered.");
                return false;
            }
            catch (SocketException)
            {
                Writer.Write($"Connection to {ip}:{port} failed.");
                return false;
            }
        }
    }
}
