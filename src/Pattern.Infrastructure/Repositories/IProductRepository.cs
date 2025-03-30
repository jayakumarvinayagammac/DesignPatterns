using Microsoft.EntityFrameworkCore;
using Pattern.Domain.Entities;
using Pattern.Infrastructure.Persistence;

namespace Pattern.Infrastructure.Repositories
{
    public interface IProductRepository<T> : IBaseRepository<T> where T : Product
    {
        // Define method signatures here
    }

    public class ProductRepository : IProductRepository<Product>
    {
        private readonly EcommerceDbContext _context;

        public ProductRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            // Implementation for retrieving all products
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            // Implementation for retrieving a product by ID
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddAsync(Product entity)
        {
            // Implementation for adding a new product
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Product entity)
        {
            // Implementation for updating an existing product
            var existingEntity = await _context.Products.FindAsync(entity.ProductId);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("Product not found.");
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Implementation for deleting a product by ID
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}