using Pattern.Domain.Common;
using Pattern.Domain.Shared;

namespace Pattern.Application.Shipment.Commands
{
    public record DeleteShipmentCommand(int ShipmentId) : ICommand<Result<ShipmentResponse>>;    
}