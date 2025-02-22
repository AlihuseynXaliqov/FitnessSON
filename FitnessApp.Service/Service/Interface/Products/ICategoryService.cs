using FitnessApp.Service.DTOs.Category;

namespace FitnessApp.Service.Service.Interface.Products;

public interface ICategoryService
{
    Task<UpdateCategoryDto> UpdateAsync(UpdateCategoryDto updateCategoryDto);
    Task<CreateCategoryDto> CreateAsync(CreateCategoryDto createCategoryDto);
    ICollection<GetCategoryDto> GetAll();
    Task<GetCategoryDto> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}