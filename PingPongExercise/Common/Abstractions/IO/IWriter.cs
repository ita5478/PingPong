namespace Common.Abstractions.IO
{
    public interface IWriter<in T>
    {
        void Write(T data);
    }
}
