using FluentValidation;

namespace FitnessApp.Service.DTOs.Plan;

public record SubscribePlanDto
{
    public int PlanId { get; set; }
    public decimal Price { get; set; }
}

public class SubscribePlanDtoValidator : AbstractValidator<SubscribePlanDto>
{
    public SubscribePlanDtoValidator()
    {
        RuleFor(x => x.PlanId)
            .GreaterThan(0).WithMessage("PlanId 0-dan böyük olmalıdır.");
    }
}