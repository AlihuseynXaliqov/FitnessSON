using FitnessApp.Service.DTOs.Class;

namespace FitnessApp.Service.Service.Interface;

public interface IClassService
{
    Task CreateClass(CreateClassDto createClassDto);
}