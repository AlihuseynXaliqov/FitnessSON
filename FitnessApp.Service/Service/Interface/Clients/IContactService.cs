using FitnessApp.Service.DTOs.Contact;

namespace FitnessApp.Service.Service.Interface.Clients;

public interface IContactService
{
    Task<CreateContactDto> Create(CreateContactDto dto);
    ICollection<GetContactDto> GetAll();
    Task<GetContactDto> GetById(int id);
    Task Delete(int id);
}