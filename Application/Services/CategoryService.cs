using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;

        }

        public async Task<IEnumerable<ResponseCategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ResponseCategoryDto>>(categories);
        }

        public async Task<ResponseCategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            return _mapper.Map<ResponseCategoryDto>(category);
        }

        public async Task<ResponseCategoryDto> CreateAsync(RequestCategoryDto dto)
        {
            var category = new Category(dto.Name);

            await _categoryRepository.CreateAsync(category);

            return _mapper.Map<ResponseCategoryDto>(category);
        }
    }
}
