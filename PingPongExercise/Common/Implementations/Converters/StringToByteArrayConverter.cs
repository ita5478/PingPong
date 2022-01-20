using Common.Abstractions.IO;
using System.Text;

namespace Common.Implementations.Converters
{
    public class StringToByteArrayConverter : IConverter<string, byte[]>
    {
        public string ConvertFrom(byte[] input)
        {
            return Encoding.ASCII.GetString(input);
        }

        public byte[] ConvertTo(string input)
        {
            return Encoding.ASCII.GetBytes(input);
        }

    }
}
