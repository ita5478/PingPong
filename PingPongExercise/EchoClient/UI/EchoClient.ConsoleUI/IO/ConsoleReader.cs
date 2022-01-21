using Common.Abstractions.IO;
using System;

namespace EchoClient.ConsoleUI.IO
{
    public class ConsoleReader : IReader<string>
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
