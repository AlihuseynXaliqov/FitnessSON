using FluentValidation;

namespace FitnessApp.Service.DTOs.Schedule;

public class UpdateScheduleDto
{
    public int Id { get; set; } 
    public int ClassId { get; set; }
    public int TrainerId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }
}
public class UpdateScheduleDtoValidator : AbstractValidator<UpdateScheduleDto>
{
    public UpdateScheduleDtoValidator()
    {
        RuleFor(x => x.ClassId)
            .GreaterThan(0).WithMessage("ClassId 0-dan böyük olmalıdır.");

        RuleFor(x => x.TrainerId)
            .GreaterThan(0).WithMessage("TrainerId 0-dan böyük olmalıdır.");

        RuleFor(x => x.DayOfWeek)
            .IsInEnum().WithMessage("Düzgün bir həftə günü seçilməlidir.");

        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("StartTime boş ola bilməz.");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("EndTime boş ola bilməz.")
            .GreaterThan(x => x.StartTime).WithMessage("EndTime, StartTime-dan böyük olmalıdır.");
    }
}