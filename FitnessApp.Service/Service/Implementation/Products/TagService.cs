using AutoMapper;
using FitnessApp.Core.Products;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Tag;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Helper.Exception.Product;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Products;

namespace FitnessApp.Service.Service.Implementation.Products;

public class TagService : ITagService
{
    private readonly ITagRepository _repository;
    private readonly IMapper _mapper;

    public TagService(ITagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateTagDto> CreateAsync(CreateTagDto dto)
    {
        if (await _repository.IsExistAsync(x => x.Name == dto.Name))
        {
            throw new TagException("Hal hazirda bu kateqoriya movcuddu", 400);
        }

        var tag = _mapper.Map<Tag>(dto);
        await _repository.AddAsync(tag);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CreateTagDto>(tag);
    }

    public async Task<GetTagDto> GetByIdAsync(int id)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);

        var tag = await _repository.GetByIdAsync(id);
        if (tag == null) throw new NotFoundException("Bele kategoriya movcud deyil", 404);

        return _mapper.Map<GetTagDto>(tag);
    }

    public ICollection<GetTagDto> GetAll()
    {
        var tags = _repository.GetAll();
        return _mapper.Map<ICollection<GetTagDto>>(tags);
    }

    public async Task<UpdateTagDto> UpdateAsync(UpdateTagDto dto)
    {
        if (dto.Id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);

        var tag = await _repository.GetByIdAsync(dto.Id);
        if (tag == null) throw new NotFoundException("Bele kategoriya movcud deyil", 404);
        if (await _repository.IsExistAsync(x => x.Name == dto.Name))
        {
            throw new TagException("Hal hazirda bu kateqoriya movcuddu", 400);
        }

        _mapper.Map(dto, tag);

        _repository.Update(tag);
        await _repository.SaveChangesAsync();
        return _mapper.Map<UpdateTagDto>(tag);
    }

    public async Task DeleteAsync(int id)
    {
        var oldTag = await GetByIdAsync(id);
        var tag = _mapper.Map<Tag>(oldTag);
        _repository.Delete(tag);
        await _repository.SaveChangesAsync();
    }
}