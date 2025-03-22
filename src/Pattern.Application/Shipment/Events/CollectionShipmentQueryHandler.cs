using Pattern.Infrastructure.Repositories;
using Pattern.Application.Queries;
using AutoMapper;
using Pattern.Domain.Common;
using MediatR;
using Pattern.Domain.Shared;

namespace Pattern.Application.Events
{
    public class CollectionShipmentQueryHandler : IQueryHandler<CollectionShipmentQuery, Result<IEnumerable<ShipmentDto>>>
    {
        private readonly IShipmentRepository<Pattern.Domain.Entities.Shipment> _shipmentRepository;
        private readonly IMapper _mapper;

        public CollectionShipmentQueryHandler(
            IShipmentRepository<Pattern.Domain.Entities.Shipment> shipmentRepository,
            IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ShipmentDto>>> Handle(CollectionShipmentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var shipments = await _shipmentRepository.GetAllAsync();
                var shipmentDtos = _mapper.Map<IEnumerable<ShipmentDto>>(shipments);
                return Result<IEnumerable<ShipmentDto>>.Success(shipmentDtos);
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                return Result<IEnumerable<ShipmentDto>>.Failure($"An error occurred while retrieving shipments: {ex.Message}");
            }
        }
    } 
}