﻿using System.Text;
using Client.BL.Abstraction;

namespace Client.BL.Implementation
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