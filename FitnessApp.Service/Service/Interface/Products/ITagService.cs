using FitnessApp.Service.DTOs.Tag;

namespace FitnessApp.Service.Service.Interface.Products;

public interface ITagService
{
    Task<CreateTagDto> CreateAsync(CreateTagDto dto);
    Task<GetTagDto> GetByIdAsync(int id);
    ICollection<GetTagDto> GetAll();
    Task<UpdateTagDto> UpdateAsync(UpdateTagDto dto);
    Task DeleteAsync(int id);
}