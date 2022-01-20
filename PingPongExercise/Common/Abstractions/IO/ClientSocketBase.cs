﻿using System.Net;

namespace Common.Abstractions.IO
{
    public abstract class ClientSocketBase
    {
        public bool IsConnected { get; protected set; }

        public abstract bool Connect(IPAddress address, int port);

        public abstract void Disconnect();

        public abstract void SendData(byte[] data);

        public abstract byte[] ReadData(int bufferSize);

    }
}
