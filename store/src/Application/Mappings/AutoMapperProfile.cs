using AutoMapper;
using Application.Dtos;
using Domain.Entities;

namespace Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ResponseClientDto>()
               .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf.Value));

            CreateMap<Category, ResponseCategoryDto>()
               .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<Product, ResponseProductDto>();


            CreateMap<Payment, ResponsePaymentDto>()
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            #region Order
            CreateMap<Order, ResponseOrderDto>()
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
               .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
               .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments));

            CreateMap<OrderItem, ResponseOrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<CreateOrderDto, Order>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Payments, opt => opt.Ignore());

            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.Ignore());
            #endregion
        }
    }
}
