﻿using Client.BL.Abstraction.IO;
using Client.BL.Abstraction;
using System.Net;
using System.Net.Sockets;
using System;

namespace Client.BL
{
    public class Client
    {
        protected ClientSocketBase ClientSocket;
        protected IWriter<string> Writer;
        protected IReader<string> Reader;
        protected IConverter<string, byte[]> Converter;

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
                if(!Connect(ip, port))
                {
                    return;
                }

                while (ClientSocket.IsConnected)
                {
                    string input = Reader.Read();

                    ClientSocket.SendData(Converter.ConvertTo(input));
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
                ClientSocket.Connect(address, port);
                Writer.Write($"Connected Succussfully to {ip}:{port}");
                return true;
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
