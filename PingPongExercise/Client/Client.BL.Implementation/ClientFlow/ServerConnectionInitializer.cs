using Client.BL.Abstraction;
using Client.BL.Abstraction.IO;
using System;
using System.Net;
using System.Net.Sockets;

namespace Client.BL.Implementation
{
    public class ServerConnectionInitializer : IConnectionInitializer
    {
        private IWriter<string> _writer;
        private ClientSocketBase _clientSocket;

        public ServerConnectionInitializer(IWriter<string> writer, ClientSocketBase clientSocket)
        {
            _writer = writer;
            _clientSocket = clientSocket;
        }

        public bool Connect(IPAddress address, int port)
        {
            try
            {
                var connectionStatus = _clientSocket.Connect(address, port);
                if (connectionStatus)
                {
                    _writer.Write($"Connected Succussfully to {address.ToString()}:{port}");
                }
                else
                {
                    _writer.Write($"Connection to {address.ToString()}:{port} failed.");
                }

                return connectionStatus;
            }
            catch (FormatException)
            {
                _writer.Write("Invalid IP format entered.");
                return false;
            }
            catch (ArgumentNullException)
            {
                _writer.Write("No IP entered.");
                return false;
            }
            catch (SocketException)
            {
                _writer.Write($"Connection to {address.ToString()}:{port} failed.");
                return false;
            }
        }
    }
}
