namespace Pattern.Application.Shipment.Commands
{
    public record CreateShipmentDto(int ShipmentId, int OrderId, DateTime ShipmentDate, string? Status, string? TrackingNumber, string? Carrier);
}