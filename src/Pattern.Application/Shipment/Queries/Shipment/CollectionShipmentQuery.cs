using Pattern.Domain.Common;
using Pattern.Domain.Shared;

namespace Pattern.Application.Queries
{
    public record CollectionShipmentQuery() : IQuery<Result<IEnumerable<ShipmentDto>>>;    
}