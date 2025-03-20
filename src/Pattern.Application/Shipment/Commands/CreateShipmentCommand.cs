using Pattern.Domain.Shared;

namespace Pattern.Application.Shipment.Commands
{
    public record CreateShipmentCommand(CreateShipmentDto ShipmentDto) : ICommand<bool>;

    public record CreateShipmentDto(int ShipmentId, int OrderId, DateTime ShipmentDate, string? Status, string? TrackingNumber, string? Carrier);
}