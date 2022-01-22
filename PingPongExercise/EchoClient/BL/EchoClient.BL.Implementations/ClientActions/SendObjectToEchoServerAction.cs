using Client.BL.Core.Policy.Abstraction;
using Common.Abstractions.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace EchoClient.BL.Implementations.ClientActions
{
    public class SendObjectToEchoServerAction : IClientAction
    {
        private ClientSocketBase _clientSocket;
        private IWriter<string> _userOutputWriter;
        private IReader<string> _userInputReader;
        public IConverter<string, byte[]> _stringToByteConverter;

        public SendObjectToEchoServerAction(
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
                    _userOutputWriter.Write("Enter a Person's name");
                    string name = _userInputReader.Read();

                    _userOutputWriter.Write("Enter a Person's age");
                    int age = int.Parse(_userInputReader.Read());

                    Person person = new Person(name, age);
                    string serialized = JsonSerializer.Serialize(person);

                    _clientSocket.SendData(_stringToByteConverter.ConvertTo(serialized));
                    _userOutputWriter.Write($"Sent {serialized} to the server.");

                    var data = _clientSocket.ReadData(serialized.Length);
                    var receivedData = _stringToByteConverter.ConvertFrom(data);
                    object returnedObject = JsonSerializer.Deserialize<Person>(receivedData);
                    _userOutputWriter.Write($"The server returned {returnedObject.ToString()}.");
                }

            }
            catch (SocketException)
            {
                _userOutputWriter.Write("There's been an error with the connection to the server.");
            }
        }
    }
}
