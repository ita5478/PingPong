using System.Net;

namespace Client.BL.Abstraction
{
    public interface IConnectionInitializer
    {
        bool Connect(IPAddress address, int port);
    }
}
