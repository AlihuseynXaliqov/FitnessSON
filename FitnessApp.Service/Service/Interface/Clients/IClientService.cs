using FitnessApp.Service.DTOs.Client;

namespace FitnessApp.Service.Service.Interface.Clients;

public interface IClientService
{
    Task<CreateFeedBackDto> CreateAsync(CreateFeedBackDto dto);
    ICollection<GetFeedBackDto> GetAllAsync();
    Task UpdateAsync(UpdateFeedBackDto dto);
    Task<GetFeedBackDto> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task ConfirmFeedBack(int id);
    ICollection<GetFeedBackDto> GetAllUnconfirmedFeedBack();
}