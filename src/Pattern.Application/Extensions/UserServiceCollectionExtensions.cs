using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pattern.Application.User;
using Pattern.Application.User.Events;
using Pattern.Application.User.Queries;
using Microsoft.Extensions.DependencyInjection;
using Pattern.Domain.Common;
using Pattern.Infrastructure.Repositories;

namespace Pattern.Application.Extensions
{
    public static class UserServiceCollectionExtensions
    {
        // Add extension methods here
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetUserQuery, Result<UserDto>>, GetUserQueryHandler>();
            services.AddTransient<IRequestHandler<CollectionUserQuery, Result<IEnumerable<UserDto>>>, CollectionUserQueryHandler>();
            services.AddScoped<IUserRepository<Pattern.Domain.Entities.User>, UserRepository>();
            return services;
        }
    }
}