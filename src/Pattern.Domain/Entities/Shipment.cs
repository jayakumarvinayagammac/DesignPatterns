namespace Pattern.Domain.Entities
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public int OrderId { get; set; }
        public DateTime ShipmentDate { get; set; } = DateTime.UtcNow;
        public string? Status { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }

        public Order? Order { get; set; }
        public ICollection<ShipmentDetail>? ShipmentDetails { get; set; }
    }
}