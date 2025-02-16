using AutoMapper;
using FitnessApp.Core.Product;
using FitnessApp.Service.DTOs.Product;

namespace FitnessApp.Service.Mapper.Product;

public class ProductProfile:Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Core.Product.Product>()
            .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages));
        // ProductImagesDto -> ProductImages dönüşümü
        CreateMap<ProductImagesDto, ProductImages>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl)); // Resim URL'sini eşle
    }
}