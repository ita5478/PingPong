using Client.BL.Abstraction.IO;
using System;

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
