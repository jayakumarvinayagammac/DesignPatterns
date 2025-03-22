using AutoMapper;
using Pattern.Application.Queries;
using Pattern.Application.Shipment;

namespace Pattern.Application.Mapping
{
    public class EcommerceMappingProfile : Profile
    {
        public EcommerceMappingProfile()
        {
            CreateMap<Pattern.Domain.Entities.Shipment, ShipmentDto>();
            CreateMap<CreateShipmentDto, Pattern.Domain.Entities.Shipment>();
        }
    }
 
}