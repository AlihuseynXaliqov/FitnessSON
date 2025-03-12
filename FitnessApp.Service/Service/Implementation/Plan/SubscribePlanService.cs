using System.Security.Claims;
using AutoMapper;
using FitnessApp.Core.Plan;
using FitnessApp.Core.User;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Plan;
using FitnessApp.Service.Helper.Exception.Auth;
using FitnessApp.Service.Service.Interface.Clients;
using FitnessApp.Service.Service.Interface.Plan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation.Plan;

public class SubscribePlanService : ISubscribePlanService
{
    private readonly ISubscribePlanRepository _repository;
    private readonly IPlanRepository _planRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public SubscribePlanService(ISubscribePlanRepository repository, IPlanRepository planRepository,
        IHttpContextAccessor httpContextAccessor,
        UserManager<AppUser> userManager,
        IMapper mapper)
    {
        _repository = repository;
        _planRepository = planRepository;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<string> SubscribePlanAfterPayment(string userId, int planId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return "İstifadəçi tapılmadı!";

        var plan = await _planRepository.Table.FirstOrDefaultAsync(x => x.Id == planId);
        if (plan == null) return "Plan tapılmadı!";

        var activePlan = _repository.GetAll("Plan").FirstOrDefault(x => x.UserId == userId && x.IsActive);
        if (activePlan != null && activePlan.EndDate > DateTime.UtcNow)
        {
            return "Sizin artıq aktiv planınız var. Yeni planı aktiv etmək üçün köhnə planın bitməsini gözləyin.";
        }

        var newPlan = new UserPlan
        {
            UserId = userId,
            PlanId = planId,
            StartDate = DateTime.UtcNow,
            EndDate = plan.Duration == DurationType.Month ? DateTime.UtcNow.AddMonths(1) : DateTime.UtcNow.AddDays((int)plan.Duration),
            IsActive = true
        };

        await _repository.AddAsync(newPlan);
        await _repository.SaveChangesAsync();
        return "Plan uğurla aktiv edildi.";
    }


    public async Task CheckAndDeactivateExpiredPlans()
    {
        var now = DateTime.UtcNow;
        var expiredPlans = await _repository.GetAll()
            .Where(x => x.IsActive && x.EndDate <= now)
            .ToListAsync();

        if (expiredPlans.Any())
        {
            foreach (var plan in expiredPlans)
            {
                _repository.Delete(plan);
            }

            await _repository.SaveChangesAsync();
        }
    }
}