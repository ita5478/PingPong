using System;
using System.Collections.Generic;
using System.Text;

namespace Client.BL.Abstraction.IO
{
    public interface IReader<out T>
    {
        T Read();
    }
}
