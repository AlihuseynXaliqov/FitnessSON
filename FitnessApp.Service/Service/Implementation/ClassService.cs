using AutoMapper;
using FitnessApp.Core;
using FitnessApp.DAL;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Class;
using FitnessApp.Service.Service.Interface;

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
        var newClass = _mapper.Map<Classes>(createClassDto);
        await _repository.AddAsync(newClass);
        await _context.SaveChangesAsync();
    }
}