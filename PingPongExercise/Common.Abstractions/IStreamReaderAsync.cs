using System.Threading.Tasks;

namespace Common.Abstractions
{
    public interface IStreamReaderAsync <T>
    {
        Task<T> ReadAsync();
    }
}
