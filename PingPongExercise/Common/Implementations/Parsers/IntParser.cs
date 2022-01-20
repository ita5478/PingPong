using System;
using Common.Abstractions.IO;

namespace Common.Implementations.Parsers
{
    public class IntParser : IParser<int>
    {
        public int Parse(string data)
        {
            return int.Parse(data);
        }
    }
}
