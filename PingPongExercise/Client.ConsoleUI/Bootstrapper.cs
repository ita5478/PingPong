using Client.BL.Implementation;

namespace Client.ConsoleUI
{
    public class Bootstrapper
    {
        public ClientRunner Initialize()
        {
            var writer = new IO.ConsoleWriter();
            var reader = new IO.ConsoleReader();

            var socket = new ClientSocket();

            ClientRunner runner = new ClientRunner(socket, writer, reader);
            return runner;
        }
    }
}
