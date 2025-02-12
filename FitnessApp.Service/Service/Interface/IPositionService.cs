using FitnessApp.Service.DTOs.Position;

namespace FitnessApp.Service.Service.Interface;

public interface IPositionService
{
    Task<CreatePositionDto> CreateAsync(CreatePositionDto dto);
    Task<GetPositionDto> GetByIdAsync(int Id);
    Task DeleteAsync(int Id);
    Task<UpdatePositionDto> UpdateAsync(UpdatePositionDto dto);
    ICollection<GetPositionDto> GetAll();

}