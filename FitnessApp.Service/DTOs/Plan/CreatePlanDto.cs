using FitnessApp.Core;
using FitnessApp.Core.Plan;
using FluentValidation;

namespace FitnessApp.Service.DTOs.Plan;

public class CreatePlanDto
{
    public string Name { get; set; }
    public DurationType Duration { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool withTrainer { get; set; } 
    public List<string> Features { get; set; }
}


public class CreatePlanDtoValidator : AbstractValidator<CreatePlanDto>
{
    public CreatePlanDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Plan adı boş ola bilməz.")
            .MinimumLength(3).WithMessage("Plan adı ən az 3 simvol olmalıdır.")
            .MaximumLength(15).WithMessage("Plan adı maksimum 15 simvol ola bilər.");

        RuleFor(x => x.Duration)
            .IsInEnum().WithMessage("Düzgün bir müddət tipi seçilməlidir.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Qiymət mənfi ola bilməz.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıqlama boş ola bilməz.")
            .MaximumLength(100).WithMessage("Açıqlama maksimum 100 simvol ola bilər.");

        RuleFor(x => x.Features)
            .NotNull().WithMessage("Xüsusiyyətlər boş ola bilməz.")
            .Must(features => features.Count > 0).WithMessage("Ən azı bir xüsusiyyət daxil edilməlidir.");

        RuleForEach(x => x.Features)
            .NotEmpty().WithMessage("Xüsusiyyət boş ola bilməz.")
            .MaximumLength(20).WithMessage("Xüsusiyyət maksimum 20 simvol ola bilər.");
    }
}
