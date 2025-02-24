using AutoMapper;
using FitnessApp.Core.Products;
using FitnessApp.Service.DTOs.Product;

namespace FitnessApp.Service.Mapper.Product;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Core.Products.Product>()
            .ForMember(dest => dest.ProductImages,
                opt => opt.MapFrom(src => src.ProductImages.Select(img => new ProductImages
                {
                    ImageUrl = img.ImageUrl
                })))
            .ForMember(dest => dest.TagProducts,
                opt => opt.MapFrom(src => src.TagIds.Select(tagId => new TagProduct { TagId = tagId })))
            .ReverseMap();

        // ProductImagesDto -> ProductImages dönüşümü
        CreateMap<ProductImagesDto, ProductImages>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ReverseMap(); // Resim URL'sini eşle

        CreateMap<Core.Products.Product, GetProductDto>()
            .ForMember(dest => dest.ProductImages,
                opt => opt.MapFrom(src => src.ProductImages.Select(pi => new ProductImagesDto
                {
                    ImageUrl = pi.ImageUrl
                })))
            .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.TagNames,
                opt => opt.MapFrom(src => src.TagProducts.Select(tp => tp.Tag.Name)))
            .ReverseMap();

        CreateMap<UpdateProductDto, Core.Products.Product>()
            .ForMember(dest => dest.ProductImages,
                opt => opt.MapFrom(src => src.ProductImages.Select(img => new ProductImages
                {
                    ImageUrl = img.ImageUrl
                })))
            .ForMember(dest => dest.TagProducts,
                opt => opt.MapFrom(src => src.TagIds.Select(tagId => new TagProduct { TagId = tagId })))
            .ReverseMap();

        CreateMap<Core.Products.Product, GetCartDto>().ReverseMap();
    }
}