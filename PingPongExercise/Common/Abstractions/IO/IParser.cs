
namespace Common.Abstractions.IO
{
    public interface IParser <out T>
    {
        T Parse(string data);
    }
}
