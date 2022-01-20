using System;
using System.Collections.Generic;
using System.Text;

namespace Client.BL.Abstraction.IO
{
    public interface IWriter <in T>
    {
        void Write(T data);
    }
}
