using Common.Abstractions.IO;
using System;

namespace EchoServer.UI
{
    public class ConsoleWriter : IWriter<string>
    {
        public void Write(string data)
        {
            Console.WriteLine(data);
        }
    }
}
