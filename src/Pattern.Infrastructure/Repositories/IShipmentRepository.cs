using Microsoft.EntityFrameworkCore;
using Pattern.Domain.Entities;
using Pattern.Infrastructure.Persistence;

namespace Pattern.Infrastructure.Repositories
{
    public interface IShipmentRepository<T> : IBaseRepository<T> where T : Shipment
    {
        // Define method signatures here
        
    }
    public class ShipmentRepository : IShipmentRepository<Shipment>
    {
        private readonly EcommerceDbContext _context;
        public ShipmentRepository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Shipment>> GetAllAsync()
        {
            // Implementation for retrieving all shipments
            return await _context.Shipments.ToListAsync();
        }

        public async Task<Shipment> GetByIdAsync(int id)
        {
            // Implementation for retrieving a shipment by ID
            return await _context.Shipments.FindAsync(id);
        }

        public async Task<Shipment> AddAsync(Shipment entity)
        {
            // Implementation for adding a new shipment
            await _context.Shipments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(Shipment entity)
        {
            // Implementation for updating an existing shipment
            var existingEntity = await _context.Shipments.FindAsync(entity.ShipmentId);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("Shipment not found.");
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();         
        }

        public async Task DeleteAsync(int id)
        {
            // Implementation for deleting a shipment by ID
            var shipment = await GetByIdAsync(id);
            if (shipment != null)
            {
                _context.Shipments.Remove(shipment);
                await _context.SaveChangesAsync();
            }            
        }       
    }
}