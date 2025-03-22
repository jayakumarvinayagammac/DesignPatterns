using Pattern.Domain.Common;
using Pattern.Domain.Shared;

namespace Pattern.Application.Queries
{
    public record GetShipmentQuery(int ShipmentId) : IQuery<Result<ShipmentDto>>;
}