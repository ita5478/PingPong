using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Abstractions.IO
{
    public interface IReader<out T>
    {
        T Read();
    }
}
