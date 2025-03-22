using Pattern.Infrastructure.Repositories;
using Pattern.Application.Queries;
using AutoMapper;
using Pattern.Domain.Common;
using Pattern.Domain.Shared;

namespace Pattern.Application.Events
{
    public class GetShipmentQueryHandler : IQueryHandler<GetShipmentQuery, Result<ShipmentDto>>
    {
        private readonly IShipmentRepository<Pattern.Domain.Entities.Shipment> _shipmentRepository;
        private readonly IMapper _mapper;

        public GetShipmentQueryHandler(
            IShipmentRepository<Pattern.Domain.Entities.Shipment> shipmentRepository,
            IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<Result<ShipmentDto>> Handle(GetShipmentQuery request, CancellationToken cancellationToken)
        {            
            try
            {
                var shipment = await _shipmentRepository.GetByIdAsync(request.ShipmentId);
                var shipmentDto = _mapper.Map<ShipmentDto>(shipment);
                return Result<ShipmentDto>.Success(shipmentDto);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return Result<ShipmentDto>.Failure($"An error occurred while retrieving the shipment: {ex.Message}");
            }
        }
    }   
}