using Client.BL.Abstraction;
using System.Net;

namespace Client.BL.Implementation
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
