using System.Security.Claims;
using AutoMapper;
using FitnessApp.Core.Blog;
using FitnessApp.Core.User;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Post;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Helper.UploadFile;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Post;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation.Post;

public class PostService:IPostService
{
    private readonly IPostRepository _repository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _web;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public PostService(IPostRepository repository,UserManager<AppUser> userManager,IMapper mapper,IWebHostEnvironment web,IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _userManager = userManager;
        _mapper = mapper;
        _web = web;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<CreatePostDto> CreateAsync(CreatePostDto createPostDto)
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("İstifadəçi daxil olmalıdır!");
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) throw new NotFoundException("İstifadəçi tapılmadı!", 404);

        var post = _mapper.Map<BlogPost>(createPostDto);
        post.UserId = userId;

        
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        post.IsActive = isAdmin;

        await _repository.AddAsync(post);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CreatePostDto>(post);
    }


    public ICollection<GetPostDto> GetAll()
    {
        var posts = _repository.GetAll("User")
            .Where(x=>x.IsActive);
        return _mapper.Map<ICollection<GetPostDto>>(posts);
    }

    public async Task<GetPostDto> GetByIdAsync(int id)
    {
        if(id<=0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var post =await _repository.GetAll("User").AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id && x.IsActive);
        if(post==null) throw new NotFoundException("Post tapilmadi",404);
        return _mapper.Map<GetPostDto>(post);
    }

    public async Task UpdateAsync(UpdatePostDto updatePostDto)
    {
        if(updatePostDto.Id<=0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var post =await _repository.GetAll("User").FirstOrDefaultAsync(x=>x.Id == updatePostDto.Id);
        if(post==null) throw new NotFoundException("Post tapilmadi",404);
        if (!string.IsNullOrEmpty(post.ImageUrl))
        {
            FileExtention.Delete(_web.WebRootPath, post.ImageUrl);
        }
        _mapper.Map( updatePostDto,post);
        _repository.Update(post);
        await _repository.SaveChangesAsync();

    }

    public async Task DeleteAsync(int id)
    {
        if(id<=0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var post =await _repository.GetAll("User").FirstOrDefaultAsync(x=>x.Id == id);
        if(post==null) throw new NotFoundException("Post tapilmadi",404);
        FileExtention.Delete(_web.WebRootPath, post.ImageUrl);
        _repository.Delete(post);
        await _repository.SaveChangesAsync();

    }
    
    public async Task ApprovePostAsync(int id)
    {
        var post = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
        if (post == null) throw new NotFoundException("Post tapılmadı", 404);

        post.IsActive = true;
        _repository.Update(post);
        await _repository.SaveChangesAsync();
    }

}