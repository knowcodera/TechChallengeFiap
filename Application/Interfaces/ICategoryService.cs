using Application.Dtos;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<ResponseCategoryDto>> GetAllAsync();
        Task<ResponseCategoryDto> GetByIdAsync(int id);
        Task<ResponseCategoryDto> CreateAsync(RequestCategoryDto category);
    }
}
