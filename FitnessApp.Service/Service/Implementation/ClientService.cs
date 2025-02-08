using AutoMapper;
using FitnessApp.Core;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Client;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public ClientService(IClientRepository repository, UserManager<AppUser> userManager, IMapper mapper)
    {
        _repository = repository;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<CreateFeedBackDto> CreateAsync(CreateFeedBackDto dto)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId);
        if (user == null) throw new NotFoundException("İstifadəçi tapılmadı!!!", 404);

        dto.UserId = user.Id;
        var feedBack = _mapper.Map<ClientFeedBack>(dto);
        await _repository.AddAsync(feedBack);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CreateFeedBackDto>(feedBack);
    }

    public ICollection<GetFeedBackDto> GetAllAsync()
    {
        var feedBacks = _repository.GetAll("User");
        return _mapper.Map<ICollection<GetFeedBackDto>>(feedBacks);
    }

    public async Task<GetFeedBackDto> GetByIdAsync(int id)
    {
        var feedBacks = await _repository.GetAll("User")
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (feedBacks == null) throw new NotFoundException("İstifadəçi tapılmadı!!!", 404);
        return _mapper.Map<GetFeedBackDto>(feedBacks);
    }

    public async Task UpdateAsync(UpdateFeedBackDto dto)
    {
        var feedback = await _repository.GetAll("User")
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (feedback == null) throw new NotFoundException("İstifadəçi tapılmadı!!!", 404);
        _mapper.Map(dto, feedback);

        _repository.Update(feedback);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var feedback = await _repository.GetAll("User")
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (feedback == null) throw new NotFoundException("İstifadəçi tapılmadı!!!", 404);
        _repository.Delete(feedback);
        await _repository.SaveChangesAsync();
    }
}