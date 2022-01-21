using System.Net;

namespace Client.BL.Core.Policy.Abstraction
{
    public interface IConnectionInitializer
    {
        bool Connect(IPAddress address, int port);
    }
}
