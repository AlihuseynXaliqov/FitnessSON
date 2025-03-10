using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Core.Blog;
using FitnessApp.Service.DTOs.Post;

namespace FitnessApp.Service.Mapper.Post;

public class PostProfile:Profile
{
    public PostProfile()
    {
        CreateMap<BlogPost, GetPostDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString("yyyy-MM-dd"))); 
        CreateMap<CreatePostDto, BlogPost>().ReverseMap();
        CreateMap<UpdatePostDto, BlogPost>().ReverseMap();
    }
    
}