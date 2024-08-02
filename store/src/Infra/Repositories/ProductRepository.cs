using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                 .Include(p => p.Category)
                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateAsync(Product Product)
        {
            await _context.Products.AddAsync(Product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product Product)
        {
            _context.Products.Update(Product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product Product)
        {
            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();
        }
    }
}
