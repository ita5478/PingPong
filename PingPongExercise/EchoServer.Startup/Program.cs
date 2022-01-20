using System;

namespace EchoServer.Startup
{
    class Program
    {
        const int PORT = 6666;
        static void Main(string[] args)
        {
            Bootstrapper boot = new Bootstrapper();
            var listener = boot.Initialize();

            listener.Bind(PORT);
            listener.ListenForClients();
        }
    }
}
