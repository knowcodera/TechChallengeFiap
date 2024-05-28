using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task CreateAsync(Product produto);
        Task UpdateAsync(Product produto);
        Task DeleteAsync(Product produto);
    }
}
