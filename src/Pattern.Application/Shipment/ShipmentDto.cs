namespace Pattern.Application.Queries
{
    public record ShipmentDto(
        int ShipmentId, 
        int OrderId, 
        DateTime ShipmentDate, 
        string? Status, 
        string? TrackingNumber, 
        string? Carrier);
}