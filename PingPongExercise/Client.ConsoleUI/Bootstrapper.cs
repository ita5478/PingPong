using Client.BL.Implementation;

namespace Client.ConsoleUI
{
    public class Bootstrapper
    {
        public ClientRunner Initialize()
        {
            var writer = new IO.ConsoleWriter();
            var reader = new IO.ConsoleReader();
            var converter = new StringToByteArrayConverter();

            var socket = new TcpClientSocket();

            ClientRunner runner = new ClientRunner(socket, writer, reader, converter);
            return runner;
        }
    }
}
