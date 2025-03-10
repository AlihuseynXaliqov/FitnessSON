using FitnessApp.Service.DTOs.Post;

namespace FitnessApp.Service.Service.Interface.Post;

public interface IPostService
{
    Task<CreatePostDto> CreateAsync(CreatePostDto createPostDto);
    ICollection<GetPostDto> GetAll();
    Task<GetPostDto> GetByIdAsync(int id);
    Task UpdateAsync(UpdatePostDto updatePostDto);
    Task DeleteAsync(int id);
    Task ApprovePostAsync(int id);
}