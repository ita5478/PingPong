
namespace EchoServer.BL.Abstraction.IO
{
    public interface IWriter <in T>
    {
        void Write(T data);
    }
}
