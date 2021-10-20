namespace Boyner.API.Results
{
    public interface IDataResult<T> : IResult
    {
        public T Data { get; }
    }
}
