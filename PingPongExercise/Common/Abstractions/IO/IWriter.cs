using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Abstractions.IO
{
    public interface IWriter <in T>
    {
        void Write(T data);
    }
}
