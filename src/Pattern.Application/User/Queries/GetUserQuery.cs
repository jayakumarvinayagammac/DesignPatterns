using Pattern.Domain.Common;
using Pattern.Domain.Shared;

namespace Pattern.Application.User.Queries
{
    public record GetUserQuery(int UserId) : IQuery<Result<UserDto>>;
}