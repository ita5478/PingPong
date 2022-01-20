using Common.Abstractions.IO;
using System.Net;

namespace Common.Implementations.Converters
{
    public class StringToIPConverter : IConverter<string, IPAddress>
    {
        public string ConvertFrom(IPAddress input)
        {
            return input.ToString();
        }

        public IPAddress ConvertTo(string input)
        {
            return IPAddress.Parse(input);
        }
    }
}
