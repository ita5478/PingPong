using System;
using Client.BL.Abstraction.IO;

namespace Client.ConsoleUI.IO
{
    public class ConsoleWriter : IWriter<string>
    {
        public void Write(string data)
        {
            Console.WriteLine(data);
        }
    }
}
