namespace Pattern.Application.Shipment
{
    public record CreateShipmentDto(
        int OrderId, 
        DateTime ShipmentDate, 
        string? Status, 
        string? TrackingNumber, 
        string? Carrier);
}