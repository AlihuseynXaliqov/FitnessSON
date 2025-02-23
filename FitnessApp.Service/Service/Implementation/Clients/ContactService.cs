using AutoMapper;
using FitnessApp.Core.Contact;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Contact;
using FitnessApp.Service.Helper.Email;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Service.Interface.Clients;
using FitnessApp.Service.Service.Interface.Users;

namespace FitnessApp.Service.Service.Implementation.Clients;

public class ContactService : IContactService
{
    private readonly IContactRepository _repository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public ContactService(IContactRepository repository, IMapper mapper,IMailService mailService)
    {
        _repository = repository;
        _mapper = mapper;
        _mailService = mailService;
    }

    public async Task<CreateContactDto> Create(CreateContactDto dto)
    {
        var contact = _mapper.Map<ContactMessage>(dto);
        await _repository.AddAsync(contact);
        await _repository.SaveChangesAsync();

        var adminMailRequest = new MailRequest
        {
            ToEmail = "alixaliq687@gmail.com",
            Subject = "Yeni əlaqə mesajı göndərildi",
            Body = $"Yeni əlaqə mesajı göndərildi:<br><br>" +
                   $"<strong>Ad:</strong> {dto.Name}<br>" +
                   $"<strong>Email:</strong> {dto.Email}<br>" +
                   $"<strong>Mövzu:</strong> {dto.Subject}<br>" +
                   $"<strong>Şərh:</strong> {dto.Message}<br><br>",
        };

        var userMailRequest = new MailRequest
        {
            ToEmail = dto.Email,
            Subject = "Təşəkkürlər! Rəyiniz üçün təşəkkür edirik",
            Body = "Rəyiniz üçün çox təşəkkür edirik. Komandamız rəylərinizi diqqətlə qiymətləndirir!<br><br>" +
                   "Ən yaxşı arzularla,<br> FitnessApp Komandası",
        };


        await Task.WhenAll(
            _mailService.SendEmailAsync(adminMailRequest),
            _mailService.SendEmailAsync(userMailRequest)
        );

        return _mapper.Map<CreateContactDto>(contact);
    }


    public ICollection<GetContactDto> GetAll()
    {
        var contacts = _repository.GetAll();
        return _mapper.Map<ICollection<GetContactDto>>(contacts);
    }

    public async Task<GetContactDto> GetById(int id)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var contact = await _repository.GetByIdAsync(id);
        if (contact == null) throw new NotFoundException("Contact tapılmadı!!!", 404);
        var contactDto = _mapper.Map<GetContactDto>(contact);
        return contactDto;
    }

    public async Task Delete(int id)
    {
        var contactDto = await GetById(id);
        var contact = _mapper.Map<ContactMessage>(contactDto);
        _repository.Delete(contact);
        await _repository.SaveChangesAsync();
    }
}