using Pattern.Domain.Common;
using Pattern.Domain.Shared;

namespace Pattern.Application.Shipment.Commands
{
    public record CreateShipmentCommand(CreateShipmentDto ShipmentDto) : ICommand<Result>;
}