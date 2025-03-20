using MediatR;

namespace Pattern.Domain.Shared
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
        where TResponse : notnull

    {
    }
}