using AutoMapper;
using FitnessApp.Core.Products;
using FitnessApp.Service.DTOs.Tag;

namespace FitnessApp.Service.Mapper.Product;

public class TagProfile:Profile
{
    public TagProfile()
    {
        CreateMap<CreateTagDto, Tag>().ReverseMap();
        CreateMap<UpdateTagDto, Tag>().ReverseMap();
        CreateMap<GetTagDto, Tag>().ReverseMap();
    }
}