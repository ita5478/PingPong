using Common.Abstractions.IO;
using Common.Implementations.Parsers;
using System.Net;

namespace Client.BL.Implementation.Parsers
{
    public class IPEndPointParser : IParser<IPEndPoint>
    {
        private IntParser intParser;
        private IpParser ipParser;

        public IPEndPointParser()
        {
            intParser = new IntParser();
            ipParser = new IpParser();
        }

        public IPEndPoint Parse(string data)
        {
            string[] parts = data.Split(':');

            var ip = ipParser.Parse(parts[0]);
            var port = intParser.Parse(parts[1]);

            return new IPEndPoint(ip, port);
        }
    }
}
