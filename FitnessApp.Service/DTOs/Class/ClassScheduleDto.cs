using FluentValidation;

namespace FitnessApp.Service.DTOs.Class;

public class ClassScheduleDto
{
    public string TrainerName { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}
public class ClassScheduleDtoValidator : AbstractValidator<ClassScheduleDto>
{
    public ClassScheduleDtoValidator()
    {
        RuleFor(x => x.TrainerName)
            .NotEmpty().WithMessage("Trainer adı tələb olunur.")
            .Length(3, 50).WithMessage("Trainer adı 3-50 simvol arasında olmalıdır.");

        RuleFor(x => x.DayOfWeek)
            .IsInEnum().WithMessage("Keçərli həftə günü daxil edin.");

        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("Başlanğıc vaxtı tələb olunur.")
            .Matches(@"^(0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$").WithMessage("Başlanğıc vaxtı HH:mm formatında olmalıdır.");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("Son vaxtı tələb olunur.")
            .Matches(@"^(0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$").WithMessage("Son vaxtı HH:mm formatında olmalıdır.")
            .GreaterThan(x => x.StartTime).WithMessage("Son vaxtı başlanğıc vaxtından sonra olmalıdır.");
    }
}
