using AutoMapper;
using FitnessApp.Core.Products;
using FitnessApp.Service.DTOs.Category;

namespace FitnessApp.Service.Mapper.Product;

public class CategoryProfile:Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryDto, Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        CreateMap<GetCategoryDto, Category>().ReverseMap();
    }
}