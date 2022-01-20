using System;
using System.Collections.Generic;
using System.Text;

namespace Client.BL.Abstraction
{
    public abstract class ClientBase
    {
        protected ClientSocketBase ClientSocket;
         

        public ClientBase(ClientSocketBase socket)
        {
            ClientSocket = socket;
        }


    }
}
