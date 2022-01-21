using Client.BL.Core.Policy.Abstraction;
using Common.Abstractions.IO;
using System.Net.Sockets;

namespace EchoClient.BL.Implementation.ClientActions
{
    public class SendMessageToEchoServerAction : IClientAction
    {
        private ClientSocketBase _clientSocket;
        private IWriter<string> _userOutputWriter;
        private IReader<string> _userInputReader;
        public IConverter<string, byte[]> _stringToByteConverter;

        public SendMessageToEchoServerAction(
            ClientSocketBase clientSocket,
            IWriter<string> userOutputWriter,
            IReader<string> userInputReader,
            IConverter<string, byte[]> stringToByteConverter)
        {
            _clientSocket = clientSocket;
            _userOutputWriter = userOutputWriter;
            _userInputReader = userInputReader;
            _stringToByteConverter = stringToByteConverter;
        }

        public void Execute()
        {
            try
            {
                while (_clientSocket.IsConnected)
                {
                    _userOutputWriter.Write("Enter a message you want to send to the server:");
                    string input = _userInputReader.Read();

                    _clientSocket.SendData(_stringToByteConverter.ConvertTo(input));
                    _userOutputWriter.Write($"Sent {input} to the server.");

                    var data = _clientSocket.ReadData(input.Length);
                    var receivedData = _stringToByteConverter.ConvertFrom(data);
                    _userOutputWriter.Write($"The server returned {receivedData}.");
                }

            }
            catch (SocketException)
            {
                _userOutputWriter.Write("There's been an error with the connection to the server.");
            }
        }
    }
}
