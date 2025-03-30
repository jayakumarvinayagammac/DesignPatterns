using Pattern.Domain.Common;
using Pattern.Domain.Shared;

namespace Pattern.Application.User.Queries
{
    public record CollectionUserQuery() : IQuery<Result<IEnumerable<UserDto>>>;
}