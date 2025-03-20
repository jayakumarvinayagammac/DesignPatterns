namespace Pattern.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public ICollection<ShipmentDetail>? ShipmentDetails { get; set; }
    }
}