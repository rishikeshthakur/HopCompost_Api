namespace HopCompost_Service.Interfaces
{
    public interface IMapper<in TSource, out TResult>
       where TSource : class
       where TResult : class
    {
        TResult Map(TSource source);
    }
}