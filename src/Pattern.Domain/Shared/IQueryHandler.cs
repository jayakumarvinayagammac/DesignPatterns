namespace Pattern.Domain.Shared
{
    public interface IQueryHandler<in TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TResponse : notnull
    { }
}