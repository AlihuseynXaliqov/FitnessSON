using AutoMapper;
using FitnessApp.Core.Plan;
using FitnessApp.Core.User;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Plan;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Helper.Exception.Plan;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Plan;
using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Service.Service.Implementation.Plan;

public class PlanService : IPlanService
{
    private readonly IPlanRepository _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _manager;

    public PlanService(IPlanRepository repository, IMapper mapper, UserManager<AppUser> manager)
    {
        _repository = repository;
        _mapper = mapper;
        _manager = manager;
    }

    public async Task<CreatePlanDto> CreateAsync(CreatePlanDto createPlanDto)
    {
        if (await _repository.IsExistAsync(x => x.Name == createPlanDto.Name))
        {
            throw new PlanException("Hal hazirda eyni adda plan var", 400);
        }

        var plan = _mapper.Map<PricingPlan>(createPlanDto);
        await _repository.AddAsync(plan);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CreatePlanDto>(plan);
    }

    public async Task<GetPlanDto> GetByIdAsync(int id)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var plan = await _repository.GetByIdAsync(id);
        if (plan == null) throw new NotFoundException("Plan tapılmadı!!!", 404);
        var planDto = _mapper.Map<GetPlanDto>(plan);
        planDto.DurationText = ((DurationType)plan.Duration).ToFriendlyString();

        return planDto;
    }

    public ICollection<GetPlanDto> GetPlansWithTrainer()
    {
        var plans = _repository.GetAll().Where(x => x.withTrainer);
        var planDtos = new List<GetPlanDto>(); 
        foreach (var plan in plans)
        {
            var planDto = _mapper.Map<GetPlanDto>(plan);
            planDto.DurationText = ((DurationType)plan.Duration).ToFriendlyString();
            planDtos.Add(planDto);
        }

        return planDtos;
    }

    public ICollection<GetPlanDto> GetPlansWithoutTrainer()
    {
        var plans = _repository.GetAll().Where(x => !x.withTrainer);
        var planDtos = new List<GetPlanDto>(); 
        foreach (var plan in plans)
        {
            var planDto = _mapper.Map<GetPlanDto>(plan);
            planDto.DurationText = ((DurationType)plan.Duration).ToFriendlyString();
            planDtos.Add(planDto);
        }

        return planDtos;    }

    public async Task<UpdatePlanDto> UpdateAsync(UpdatePlanDto updatePlanDto)
    {
        if (updatePlanDto.Id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var plan = await _repository.GetByIdAsync(updatePlanDto.Id);
        if (plan == null) throw new NotFoundException("Plan tapılmadı!!!", 404);
        if (await _repository.IsExistAsync(x => x.Name == updatePlanDto.Name
                                                && x.Id != updatePlanDto.Id))
        {
            throw new PlanException("Hal hazirda eyni adda plan var", 400);
        }

        _mapper.Map(updatePlanDto, plan);
        _repository.Update(plan);
        await _repository.SaveChangesAsync();
        return _mapper.Map<UpdatePlanDto>(plan);
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var plan = await _repository.GetByIdAsync(id);
        if (plan == null) throw new NotFoundException("Plan tapılmadı!!!", 404);
        _repository.Delete(plan);
        await _repository.SaveChangesAsync();
    }
}