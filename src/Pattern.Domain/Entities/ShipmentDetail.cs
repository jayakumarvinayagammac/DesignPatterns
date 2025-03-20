namespace Pattern.Domain.Entities
{
    public class ShipmentDetail
    {
        public int ShipmentDetailId { get; set; }
        public int ShipmentId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Shipment? Shipment { get; set; }
        public Product? Product { get; set; }
    }
}