namespace EchoClient.Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper boot = new Bootstrapper();
            var runner = boot.Initialize();

            string[] parts = args[0].Split(':');

            runner.Start(parts[0], int.Parse(parts[1]));
        }
    }
}
