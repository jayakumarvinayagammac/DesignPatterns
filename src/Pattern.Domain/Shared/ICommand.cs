using MediatR;

namespace Pattern.Domain.Shared
{
    public interface ICommand<out TResult> : IRequest<TResult>
        where TResult : notnull
    {
    }
}