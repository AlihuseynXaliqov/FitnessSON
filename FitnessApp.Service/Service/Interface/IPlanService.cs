using FitnessApp.Service.DTOs.Plan;

namespace FitnessApp.Service.Service.Interface;

public interface IPlanService
{

    Task<CreatePlanDto> CreateAsync(CreatePlanDto createPlanDto);
    Task<GetPlanDto> GetByIdAsync(int id);
    ICollection<GetPlanDto> GetPlansWithoutTrainer();
    ICollection<GetPlanDto> GetPlansWithTrainer();
    Task<UpdatePlanDto> UpdateAsync(UpdatePlanDto updatePlanDto);
    Task DeleteAsync(int id);
}