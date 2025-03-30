using Microsoft.EntityFrameworkCore;
using Pattern.Domain.Entities;
using Pattern.Infrastructure.Persistence;

namespace Pattern.Infrastructure.Repositories
{
    public interface IOrderRepository<T> : IBaseRepository<T> where T : Order
    {
        // Define method signatures here
    }
    
    public class OrderRepository : IOrderRepository<Order>
    {
        private readonly EcommerceDbContext _context;

        public OrderRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var order = await GetByIdAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();      
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task UpdateAsync(Order entity)
        {
            var existingEntity = await _context.Orders.FindAsync(entity.OrderId);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("Product not found.");
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}