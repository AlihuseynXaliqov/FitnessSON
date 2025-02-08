using FitnessApp.Service.DTOs.Client;

namespace FitnessApp.Service.Service.Interface;

public interface IClientService
{
    Task<CreateFeedBackDto> CreateAsync(CreateFeedBackDto dto);
    ICollection<GetFeedBackDto> GetAllAsync();
    Task UpdateAsync(UpdateFeedBackDto dto);
    Task<GetFeedBackDto> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}