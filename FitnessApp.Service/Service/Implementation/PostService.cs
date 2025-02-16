using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Core.Blog;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Post;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Helper.UploadFile;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation;

public class PostService:IPostService
{
    private readonly IPostRepository _repository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _web;


    public PostService(IPostRepository repository,IMapper mapper,IWebHostEnvironment web)
    {
        _repository = repository;
        _mapper = mapper;
        _web = web;
    }
    
    public async Task<CreatePostDto> CreateAsync(CreatePostDto createPostDto)
    {
        var post=_mapper.Map<BlogPost>(createPostDto);
        await _repository.AddAsync(post);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CreatePostDto>(post);
    }

    public ICollection<GetPostDto> GetAll()
    {
        var posts = _repository.GetAll("User");
        return _mapper.Map<ICollection<GetPostDto>>(posts);
    }

    public async Task<GetPostDto> GetByIdAsync(int id)
    {
        if(id<=0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var post =await _repository.GetAll("User").AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
        if(post==null) throw new NotFoundException("Post tapilmadi",404);
        return _mapper.Map<GetPostDto>(post);
    }

    public async Task UpdateAsync(UpdatePostDto updatePostDto)
    {
        if(updatePostDto.Id<=0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var post =await _repository.GetAll("User").FirstOrDefaultAsync(x=>x.Id == updatePostDto.Id);
        if(post==null) throw new NotFoundException("Post tapilmadi",404);
        FileExtention.Delete(_web.WebRootPath, post.ImageUrl);
        _mapper.Map( updatePostDto,post);
        _repository.Update(post);
        await _repository.SaveChangesAsync();

    }

    public async Task DeleteAsync(int id)
    {
        if(id<=0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var post =await _repository.GetAll("User").FirstOrDefaultAsync(x=>x.Id == id);
        FileExtention.Delete(_web.WebRootPath, post.ImageUrl);
        if(post==null) throw new NotFoundException("Post tapilmadi",404);
        _repository.Delete(post);
        await _repository.SaveChangesAsync();

    }
}