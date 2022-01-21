using Common.Abstractions.IO;
using System;

namespace EchoServer.BL.Implementation
{
    public class ConsoleWriter : IWriter<string>
    {
        public void Write(string data)
        {
            Console.WriteLine(data);
        }
    }
}
