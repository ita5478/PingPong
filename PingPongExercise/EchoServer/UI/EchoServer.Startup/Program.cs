namespace EchoServer.Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = int.Parse(args[0]);
            
            Bootstrapper boot = new Bootstrapper();
            var listener = boot.Initialize();
            listener.Bind(port);
            listener.ListenForClients();
        }
    }
}
