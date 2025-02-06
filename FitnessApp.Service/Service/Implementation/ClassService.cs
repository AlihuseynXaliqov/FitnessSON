using AutoMapper;
using FitnessApp.Core;
using FitnessApp.DAL;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Class;
using FitnessApp.Service.Helper.Exception.Classes;
using FitnessApp.Service.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation;

public class ClassService : IClassService
{
    private readonly AppDbContext _context;
    private readonly IClassRepository _repository;
    private readonly IMapper _mapper;

    public ClassService(AppDbContext context, IClassRepository classRepository, IMapper mapper)
    {
        _context = context;
        _repository = classRepository;
        _mapper = mapper;
    }

    public async Task CreateClass(CreateClassDto createClassDto)
    {
        var existingClass = await _repository.Table.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == createClassDto.Name);

        if (existingClass != null)
        {
            if (existingClass.IsDeleted)
            {
                existingClass.IsDeleted = false;
                existingClass.UpdateAt = DateTime.UtcNow;
                _repository.Update(existingClass);
            }
            else
            {
                throw new ClassException("Bu idman novu hal-hazirda movcuddur", 404);
            }
        }
        else
        {
            var newClass = _mapper.Map<Classes>(createClassDto);
            await _repository.AddAsync(newClass);
        }

        await _repository.SaveChangesAsync();
    }


    public async Task<GetClassDto> GetClass(int id)
    {
        if (id <= 0) throw new ClassException("Id menfi ve ya sifir ola bilmez", 404);
        var classes = await _repository.GetByIdAsync(id);
        var classDto = _mapper.Map<GetClassDto>(classes);
        return classDto;
    }

    public ICollection<GetClassDto> GetAllClasses()
    {
        var classes = _repository.GetAll();
        return _mapper.Map<ICollection<GetClassDto>>(classes);
    }

    public async Task UpdateClass(UpdateClassDto updateClassDto)
    {
        if (updateClassDto.Id <= 0)
            throw new ClassException("Id menfi ve ya sifir ola bilmez", 404);

        var oldClass = await _repository.Table.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == updateClassDto.Id);

        if (oldClass == null)
            throw new ClassException("Bele idman novu movcud deyil", 404);

        var deletedClass = await _repository.Table.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == updateClassDto.Name && x.IsDeleted);

        if (deletedClass != null)
        {
            deletedClass.IsDeleted = false;
            deletedClass.UpdateAt = DateTime.UtcNow;
            deletedClass.Description = updateClassDto.Description;
            deletedClass.ImageUrl = updateClassDto.ImageUrl;
            _context.Entry(deletedClass).State = EntityState.Detached; 
            _repository.Update(deletedClass);
        }
        else
        {
            var newClass = _mapper.Map<GetClassDto>(updateClassDto);
            _repository.Update(_mapper.Map<Classes>(newClass));
        }

        await _repository.SaveChangesAsync();
    }

    public async Task DeleteClass(int id)
    {
        var classes = await GetClass(id);

        _repository.Delete(_mapper.Map<Classes>(classes));
        await _repository.SaveChangesAsync();
    }
}