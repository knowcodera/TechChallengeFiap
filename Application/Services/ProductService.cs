using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ResponseProductDto>> GetAllAsync()
        {
            var product = await _productRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ResponseProductDto>>(product);
        }

        public async Task<ResponseProductDto> GetByIdAsync(int id)
        {
            var produtct = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ResponseProductDto>(produtct);
        }

        public async Task<ResponseProductDto> CreateAsync(RequestProductDto dto)
        {
            var product = new Product(dto.Name, dto.Price, dto.CategoryId);

            await _productRepository.CreateAsync(product);

            return _mapper.Map<ResponseProductDto>(product);
        }

        public async Task<ResponseProductDto> UpdateProduct(int id, RequestProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null) return null;

            product.Update(dto.Name, dto.Price, dto.CategoryId);

            await _productRepository.UpdateAsync(product);

            return _mapper.Map<ResponseProductDto>(product);
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null) return;

            await _productRepository.DeleteAsync(product);
        }
    }
}
