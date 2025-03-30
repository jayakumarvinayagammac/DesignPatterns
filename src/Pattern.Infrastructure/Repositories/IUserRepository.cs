using Microsoft.EntityFrameworkCore;
using Pattern.Domain.Entities;
using Pattern.Infrastructure.Persistence;

namespace Pattern.Infrastructure.Repositories
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : User
    {
        // Define method signatures here
    }

    public class UserRepository : IUserRepository<User>
    {
        private readonly EcommerceDbContext _context;

        public UserRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            // Implementation for retrieving all users
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            // Implementation for retrieving a user by ID
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> AddAsync(User entity)
        {
            // Implementation for adding a new user
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(User entity)
        {
            // Implementation for updating an existing user
            var existingEntity = await _context.Users.FindAsync(entity.UserId);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Implementation for deleting a user by ID
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}