using Pattern.Application.Shipment.Commands;
using Pattern.Domain.Shared;
using Microsoft.Extensions.Logging;
using Pattern.Domain.Common;
using Pattern.Infrastructure.Repositories;
using AutoMapper;
using Pattern.Application.Shipment;

namespace Pattern.Application.Events
{
    public class UpdateShipmentCommandHandler : ICommandHandler<UpdateShipmentCommand, Result<ShipmentResponse>>
    {
        private readonly ILogger<UpdateShipmentCommandHandler> _logger;
        private readonly IShipmentRepository<Pattern.Domain.Entities.Shipment> _shipmentRepository;
        private readonly IMapper _mapper;

        public UpdateShipmentCommandHandler(ILogger<UpdateShipmentCommandHandler> logger, IShipmentRepository<Pattern.Domain.Entities.Shipment> shipmentRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Result<ShipmentResponse>> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
        {
            // Placeholder for handling the command
            try
            {                              
                // Placeholder for updating a shipment
                var updatedShipment = _mapper.Map<Pattern.Domain.Entities.Shipment>(request.Shipment);
                updatedShipment.ShipmentId = request.ShipmentId;
                await _shipmentRepository.UpdateAsync(updatedShipment);
                ShipmentResponse response = new ShipmentResponse(updatedShipment.ShipmentId);
                return Result<ShipmentResponse>.Success(response);
            }
            catch (Exception ex)
            {
                // TODO
                return Result<ShipmentResponse>.Failure(FollowerErrors.AlreadyFollowing.ToString());
            }
        }
    }
}