using AutoMapper;
using FitnessApp.Core.Products;
using FitnessApp.Service.DTOs.Product;

namespace FitnessApp.Service.Mapper.Product;

public class ProductProfile:Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Core.Products.Product>()
            .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages)).ReverseMap();
        // ProductImagesDto -> ProductImages dönüşümü
        CreateMap<ProductImagesDto, ProductImages>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl)).ReverseMap(); // Resim URL'sini eşle
    }
}