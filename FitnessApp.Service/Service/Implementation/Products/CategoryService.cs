using AutoMapper;
using FitnessApp.Core.Products;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Category;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Helper.Exception.Product;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Products;

namespace FitnessApp.Service.Service.Implementation.Products;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateCategoryDto> CreateAsync(CreateCategoryDto createCategoryDto)
    {
        if (await _repository.IsExistAsync(x => x.Name == createCategoryDto.Name))
        {
            throw new CategoryException("Hal hazirda bu kateqoriya movcuddu", 400);
        }

        var category = _mapper.Map<Category>(createCategoryDto);
        await _repository.AddAsync(category);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CreateCategoryDto>(category);
    }

    public async Task<GetCategoryDto> GetByIdAsync(int id)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);

        var category = await _repository.GetByIdAsync(id);
        if (category == null) throw new NotFoundException("Bele kategoriya movcud deyil", 404);

        return _mapper.Map<GetCategoryDto>(category);
    }

    public ICollection<GetCategoryDto> GetAll()
    {
        var categories = _repository.GetAll();
        return _mapper.Map<ICollection<GetCategoryDto>>(categories);
    }

    public async Task<UpdateCategoryDto> UpdateAsync(UpdateCategoryDto updateCategoryDto)
    {
        if (updateCategoryDto.Id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);

        var category = await _repository.GetByIdAsync(updateCategoryDto.Id);
        if (category == null) throw new NotFoundException("Bele kategoriya movcud deyil", 404);
        if (await _repository.IsExistAsync(x => x.Name == updateCategoryDto.Name))
        {
            throw new CategoryException("Hal hazirda bu kateqoriya movcuddu", 400);
        }
        
        _mapper.Map(updateCategoryDto, category);

        _repository.Update(category);
        await _repository.SaveChangesAsync();
        return _mapper.Map<UpdateCategoryDto>(category);
    }

    public async Task DeleteAsync(int id)
    {
        var oldCategory = await GetByIdAsync(id);
        var category = _mapper.Map<Category>(oldCategory);
        _repository.Delete(category);
        await _repository.SaveChangesAsync();
    }
}