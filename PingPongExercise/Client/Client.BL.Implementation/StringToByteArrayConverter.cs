using System.Text;
using Client.BL.Abstraction;

namespace Client.BL.Implementation
{
    public class StringToByteArrayConverter : IConverter<string, byte[]>
    {
        public byte[] Convert(string input)
        {
            return Encoding.ASCII.GetBytes(input);
        }
    }
}
