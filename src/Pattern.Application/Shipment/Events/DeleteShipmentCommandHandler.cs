using Pattern.Application.Shipment.Commands;
using Pattern.Domain.Shared;
using Microsoft.Extensions.Logging;
using Pattern.Domain.Common;
using Pattern.Infrastructure.Repositories;
using AutoMapper;
using Pattern.Application.Shipment;

namespace Pattern.Application.Events
{
    public class DeleteShipmentCommandHandler : ICommandHandler<DeleteShipmentCommand, Result<ShipmentResponse>>
    {
        private readonly ILogger<DeleteShipmentCommandHandler> _logger;
        private readonly IShipmentRepository<Pattern.Domain.Entities.Shipment> _shipmentRepository;
        private readonly IMapper _mapper;

        public DeleteShipmentCommandHandler(ILogger<DeleteShipmentCommandHandler> logger, IShipmentRepository<Pattern.Domain.Entities.Shipment> shipmentRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Result<ShipmentResponse>> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling DeleteShipmentCommand");
            _logger.LogInformation("Request details: {@Request}", request);
            // Placeholder for handling the command
            await Task.Delay(1000);
            try
            {
                // Placeholder for deleting a shipment
                var shipment = await _shipmentRepository.GetByIdAsync(request.ShipmentId);
                if (shipment == null)
                {
                    return Result<ShipmentResponse>.Failure(FollowerErrors.AlreadyFollowing.ToString());
                }
                await _shipmentRepository.DeleteAsync(shipment.ShipmentId);
                return Result<ShipmentResponse>.Success(new ShipmentResponse(shipment.ShipmentId));
            }
            catch (Exception ex)
            {
                // TODO
                return Result<ShipmentResponse>.Failure(FollowerErrors.AlreadyFollowing.ToString());
            }
        }
    }
}