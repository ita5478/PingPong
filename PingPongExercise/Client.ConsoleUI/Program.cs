namespace Client.ConsoleUI
{
    class Program
    {
        const string IP = "127.0.0.1";
        const int PORT = 6666;
        static void Main(string[] args)
        {
            Bootstrapper boot = new Bootstrapper();
            var runner = boot.Initialize();

            runner.Start(IP, PORT);
        }
    }
}
