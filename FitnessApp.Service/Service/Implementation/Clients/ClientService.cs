﻿using System.Security.Claims;
using AutoMapper;
using FitnessApp.Core.FeedBack;
using FitnessApp.Core.User;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Client;
using FitnessApp.Service.Helper.Email;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Helper.UploadFile;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Clients;
using MailKit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IMailService = FitnessApp.Service.Service.Interface.Users.IMailService;

namespace FitnessApp.Service.Service.Implementation.Clients;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _web;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMailService _service;

    public ClientService(IClientRepository repository,
        UserManager<AppUser> userManager,
        IMapper mapper,
        IWebHostEnvironment web,
        IHttpContextAccessor httpContextAccessor,
        IMailService service)
    {
        _repository = repository;
        _userManager = userManager;
        _mapper = mapper;
        _web = web;
        _httpContextAccessor = httpContextAccessor;
        _service = service;
    }

    public async Task<CreateFeedBackDto> CreateAsync(CreateFeedBackDto dto)
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("İstifadəçi daxil olmalıdır!");
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) throw new NotFoundException("İstifadəçi tapılmadı!!!", 404);


        var feedBack = _mapper.Map<ClientFeedBack>(dto);
        feedBack.UserId = userId;
        feedBack.ConfirmedFeedBack = false;
        await _repository.AddAsync(feedBack);
        await _repository.SaveChangesAsync();

        var adminMailRequest = new MailRequest
        {
            ToEmail = "alixaliq687@gmail.com",
            Subject = "Yeni Rəy Göndərildi",
            Body = $"Yeni bir rəy əlavə olundu:<br><br>" +
                   $"<strong>Ad/Soyad:</strong> {user.FirstName} {user.LastName}<br>" +
                   $"<strong>Qiymətləndirmə:</strong> {dto.Rating} ulduz<br>" +
                   $"<strong>Şərh:</strong> {dto.Description}<br><br>",
        };

        var userMailRequest = new MailRequest
        {
            ToEmail = user.Email,
            Subject = "Təşəkkürlər! Rəyiniz üçün təşəkkür edirik",
            Body = "Rəyiniz üçün çox təşəkkür edirik. Komandamız rəylərinizi diqqətlə qiymətləndirir!<br><br>" +
                   "Ən yaxşı arzularla,<br> FitnessApp Komandası",
        };

        await Task.WhenAll(_service.SendEmailAsync(adminMailRequest), _service.SendEmailAsync(userMailRequest));
        return _mapper.Map<CreateFeedBackDto>(feedBack);
    }

    public ICollection<GetFeedBackDto> GetAllAsync()
    {
        var feedBacks = _repository.GetAll("User").Where(x => x.ConfirmedFeedBack);
        return _mapper.Map<ICollection<GetFeedBackDto>>(feedBacks);
    }

    public async Task<GetFeedBackDto> GetByIdAsync(int id)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var feedBacks = await _repository.GetAll("User")
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.ConfirmedFeedBack);
        if (feedBacks == null) throw new NotFoundException("Rəy tapılmadı!!!", 404);
        return _mapper.Map<GetFeedBackDto>(feedBacks);
    }

    public async Task UpdateAsync(UpdateFeedBackDto dto)
    {
        if (dto.Id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);

        var feedback = await _repository.GetAll("User")
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (feedback == null) throw new NotFoundException("Rəy tapılmadı!!!", 404);
        FileExtention.Delete(_web.WebRootPath, feedback.ImageUrl);

        _mapper.Map(dto, feedback);

        _repository.Update(feedback);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var feedback = await _repository.GetAll("User")
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (feedback == null) throw new NotFoundException("Rəy tapılmadı!!!", 404);
        FileExtention.Delete(_web.WebRootPath, feedback.ImageUrl);
        _repository.Delete(feedback);
        await _repository.SaveChangesAsync();
    }

    public async Task ConfirmFeedBack(int id)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var feedback = await _repository.GetAll("User")
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.ConfirmedFeedBack);
        if (feedback == null) throw new NotFoundException("Rəy tapılmadı!!!", 404);
        feedback.ConfirmedFeedBack = true;

        _repository.Update(feedback);
        await _repository.SaveChangesAsync();
    }

    public ICollection<GetFeedBackDto> GetAllUnconfirmedFeedBack()
    {
        var unconfirmedFeedBacks = _repository.GetAll("User")
            .Where(x => !x.ConfirmedFeedBack);
        return _mapper.Map<ICollection<GetFeedBackDto>>(unconfirmedFeedBacks);
    }
}