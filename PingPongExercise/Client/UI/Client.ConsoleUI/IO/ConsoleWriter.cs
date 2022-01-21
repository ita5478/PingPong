using Common.Abstractions.IO;
using System;

namespace EchoClient.ConsoleUI.IO
{
    public class ConsoleWriter : IWriter<string>
    {
        public void Write(string data)
        {
            Console.WriteLine(data);
        }
    }
}
