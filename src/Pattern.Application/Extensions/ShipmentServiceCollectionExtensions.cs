using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pattern.Application.Events;
using Pattern.Application.Queries;
using Pattern.Application.Shipment;
using Pattern.Application.Shipment.Commands;
using Pattern.Domain.Common;
using Pattern.Infrastructure.Repositories;

namespace Pattern.Application.Extensions
{
    public static class ShipmentServiceCollectionExtensions
    {
        // Add extension methods here
        public static IServiceCollection AddShipmentServices(this IServiceCollection services)
        {            
            services.AddTransient<IRequestHandler<CreateShipmentCommand, Result<ShipmentResponse>>, CreateShipmentCommandHandler>();
            services.AddTransient<IRequestHandler<CollectionShipmentQuery, Result<IEnumerable<ShipmentDto>>>, CollectionShipmentQueryHandler>();
            services.AddTransient<IRequestHandler<GetShipmentQuery, Result<ShipmentDto>>, GetShipmentQueryHandler>();
            services.AddTransient<IRequestHandler<UpdateShipmentCommand, Result<ShipmentResponse>>, UpdateShipmentCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteShipmentCommand, Result<ShipmentResponse>>, DeleteShipmentCommandHandler>();
            services.AddScoped<IShipmentRepository<Pattern.Domain.Entities.Shipment>, ShipmentRepository>();
            
            return services;
        }
    }
}