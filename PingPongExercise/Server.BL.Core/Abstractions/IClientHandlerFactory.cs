
namespace EchoServer.BL.Abstraction
{
    public interface IClientHandlerFactory
    {
        IClientHandler Create(SocketWrappers.ISocketStreamWrapper socketWrapper);
    }
}
