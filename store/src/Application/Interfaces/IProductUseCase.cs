using Application.Dtos;

namespace Application.Interfaces
{
    public interface IProductUseCase
    {
        Task<IEnumerable<ResponseProductDto>> GetAllAsync();
        Task<ResponseProductDto> GetByIdAsync(int id);
        Task<ResponseProductDto> CreateAsync(RequestProductDto product);
        Task<ResponseProductDto> UpdateProduct(int id, RequestProductDto product);
        Task DeleteProduct(int id);
    }
}
