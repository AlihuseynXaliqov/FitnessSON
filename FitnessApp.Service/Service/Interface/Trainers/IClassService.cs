using FitnessApp.Service.DTOs.Class;

namespace FitnessApp.Service.Service.Interface.Trainers;

public interface IClassService
{
    Task CreateClass(CreateClassDto createClassDto);
    Task<GetClassDto> GetClass(int id);
    ICollection<GetClassDto> GetAllClasses();
    Task UpdateClass(UpdateClassDto updateClassDto);
    Task DeleteClass(int id);
}