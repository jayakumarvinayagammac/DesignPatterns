using Pattern.Application.Shipment.Commands;
using Pattern.Domain.Shared;
using Microsoft.Extensions.Logging;
using Pattern.Domain.Common;
using Pattern.Infrastructure.Repositories;
using AutoMapper;
using Pattern.Application.Shipment;

namespace Pattern.Application.Events
{
    public class CreateShipmentCommandHandler : ICommandHandler<CreateShipmentCommand, Result<ShipmentResponse>>
    {
        private readonly ILogger<CreateShipmentCommandHandler> _logger;
        private readonly IShipmentRepository<Pattern.Domain.Entities.Shipment> _shipmentRepository;
        private readonly IMapper _mapper;

        public CreateShipmentCommandHandler(ILogger<CreateShipmentCommandHandler> logger, IShipmentRepository<Pattern.Domain.Entities.Shipment> shipmentRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Result<ShipmentResponse>> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling CreateShipmentCommand");
            _logger.LogInformation("Request details: {@Request}", request);
            // Placeholder for handling the command
            await Task.Delay(1000);
            try
            {
                // Placeholder for creating a new shipment                
                 var shipment = _mapper.Map<Pattern.Domain.Entities.Shipment>(request.ShipmentDto);
                var shipmentResponse = await _shipmentRepository.AddAsync(shipment);
                ShipmentResponse response = new ShipmentResponse(shipmentResponse.ShipmentId);
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