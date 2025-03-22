using Pattern.Domain.Common;
using Pattern.Domain.Shared;

namespace Pattern.Application.Shipment.Commands
{
    public record UpdateShipmentCommand(
        int ShipmentId,
        CreateShipmentDto Shipment
    ) : ICommand<Result<ShipmentResponse>>;
}