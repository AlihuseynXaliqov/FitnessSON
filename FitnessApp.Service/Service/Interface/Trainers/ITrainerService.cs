using FitnessApp.Service.DTOs.Trainer;

namespace FitnessApp.Service.Service.Interface.Trainers;

public interface ITrainerService
{
    Task<CreateTrainerDto> CreateTrainerAsync(CreateTrainerDto dto);
    Task<GetTrainerDto> GetTrainerByIdAsync(int Id);
    ICollection<GetTrainerDto> GetTrainers();
    Task<UpdateTrainerDto> UpdateTrainerAsync(UpdateTrainerDto dto);
    Task Delete(int Id);
}