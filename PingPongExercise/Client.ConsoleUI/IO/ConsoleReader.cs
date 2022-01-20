using System;
using Client.BL.Abstraction.IO;

namespace Client.ConsoleUI.IO
{
    public class ConsoleReader : IReader<string>
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
