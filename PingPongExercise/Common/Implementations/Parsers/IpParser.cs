using Common.Abstractions.IO;
using System.Net;

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
