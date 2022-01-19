using System.Threading.Tasks;

namespace Common.Abstractions
{
    public interface IStreamWriterAsync <in T>
    {
        Task Write(T data);
    }
}
