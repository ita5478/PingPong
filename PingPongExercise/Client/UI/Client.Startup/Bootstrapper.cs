using Client.BL.Core.Implementation;
using Client.BL.Core.Policy;
using Common.Implementations.Converters;
using EchoClient.BL.Implementation.ClientActions;
using EchoClient.ConsoleUI.IO;

namespace EchoClient.Startup
{
    public class Bootstrapper
    {
        public ClientRunner Initialize()
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();

            var stringToByteConverter = new StringToByteArrayConverter();
            var stringToIPConverter = new StringToIPConverter();

            var socket = new TcpClientSocket();

            var connectionInitializer = new ServerConnectionInitializer(writer, socket);
            var clientAction = new SendMessageToEchoServerAction(socket, writer, reader, stringToByteConverter);

            ClientRunner runner = new ClientRunner(connectionInitializer, clientAction, stringToIPConverter);
            return runner;
        }
    }
}
