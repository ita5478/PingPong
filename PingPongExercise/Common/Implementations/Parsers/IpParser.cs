using System.Net;
using Common.Abstractions.IO;

namespace Common.Implementations.Parsers
{
    public class IpParser : IParser<IPAddress>
    {
        public IPAddress Parse(string data)
        {
            return IPAddress.Parse(data);
        }
    }
}
