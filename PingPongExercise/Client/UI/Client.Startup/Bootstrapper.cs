using Client.BL.Core.Implementation;
using Client.BL.Implementation;
using Client.ConsoleUI.IO;
using Common.Implementations.Converters;

namespace Client.Startup
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
