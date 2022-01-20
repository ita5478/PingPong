
namespace Client.BL.Abstraction
{
    public interface IParser <out T>
    {
        T Parser(string data);
    }
}
