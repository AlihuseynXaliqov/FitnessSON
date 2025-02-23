using AutoMapper;
using FitnessApp.Core.Contact;
using FitnessApp.Service.DTOs.Contact;

namespace FitnessApp.Service.Mapper.Client;

public class ContactProfile:Profile
{
    public ContactProfile()
    {
        CreateMap<GetContactDto, ContactMessage>().ReverseMap();
        CreateMap<CreateContactDto, ContactMessage>().ReverseMap();
    }
}