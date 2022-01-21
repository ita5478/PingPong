
namespace Server.Core.BL.Abstractions
{
    public interface IClientHandlerFactory
    {
        IClientHandler Create(ISocketStreamWrapper socketWrapper);
    }
}
