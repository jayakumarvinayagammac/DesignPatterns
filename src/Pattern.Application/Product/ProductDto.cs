namespace Pattern.Application.Product
{
    public record ProductDto(
        int ProductId, 
        string? Name, 
        string? Description, 
        decimal Price, 
        int Stock, 
        DateTime CreatedAt
    );
}