using Domain.Dtos;

namespace Domain.Interfaces
{
    public interface ICategoryUseCase
    {
        Task<IEnumerable<ResponseCategoryDto>> GetAllAsync();
        Task<ResponseCategoryDto> GetByIdAsync(int id);
        Task<ResponseCategoryDto> CreateAsync(RequestCategoryDto category);
    }
}
