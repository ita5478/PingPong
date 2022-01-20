namespace Common.Abstractions.IO
{
    public interface IReader<out T>
    {
        T Read();
    }
}
