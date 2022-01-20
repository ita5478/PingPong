using Client.BL.Implementation;
using Common.Implementations.Converters;

namespace Client.ConsoleUI
{
    public class Bootstrapper
    {
        public ClientRunner Initialize()
        {
            var writer = new IO.ConsoleWriter();
            var reader = new IO.ConsoleReader();

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
