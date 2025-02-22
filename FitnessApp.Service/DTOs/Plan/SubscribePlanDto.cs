using FluentValidation;

namespace FitnessApp.Service.DTOs.Plan;

public class SubscribePlanDto
{
    public int PlanId { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsActive { get; set; }
}
public class SubscribePlanDtoValidator : AbstractValidator<SubscribePlanDto>
{
    public SubscribePlanDtoValidator()
    {
        RuleFor(x => x.PlanId)
            .GreaterThan(0).WithMessage("PlanId 0-dan böyük olmalıdır.");

        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Başlama tarixi bu gün və ya gələcək bir tarix olmalıdır.");
    }
}