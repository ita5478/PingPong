using System.Threading;
using System.Threading.Tasks;

namespace Server.Core.BL.Abstractions
{
    public interface IClientHandler
    {
        Task HandleClient(CancellationToken token);
    }
}
