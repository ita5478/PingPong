using System.Net;

namespace Client.BL.Core.Abstraction
{
    public interface IConnectionInitializer
    {
        bool Connect(IPAddress address, int port);
    }
}
