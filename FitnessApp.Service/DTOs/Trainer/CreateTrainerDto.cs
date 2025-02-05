using FluentValidation;

namespace FitnessApp.Service.DTOs.Trainer;

public class CreateTrainerDto
{
    public string FirstName { get; set; }  
    public string LastName { get; set; } 
    public string ImageUrl { get; set; }   
    public string Specialization { get; set; }  // Mütəxəssisi olduğu sahə (Fitness, CrossFit və s.)
    public string Biography { get; set; }
    public string Experience { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string FacebookUrl { get; set; }
    public string InstagramUrl { get; set; }
    public string TwitterUrl { get; set; }
}

public class CreateTrainerValidator : AbstractValidator<CreateTrainerDto>
{
    public CreateTrainerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull().WithMessage("Ad boş ola bilməz")
            .NotEmpty().WithMessage("Ad boş ola bilməz")
            .MaximumLength(20).WithMessage("Ad ən çox 20 simvoldan ibarət ola bilər")
            .MinimumLength(4).WithMessage("Ad ən çox 4 simvoldan ibarət ola bilər");
        
        RuleFor(x => x.LastName)
            .NotNull().WithMessage("Soyad boş ola bilməz")
            .NotEmpty().WithMessage("Soyad boş ola bilməz")
            .MaximumLength(20).WithMessage("Soyad ən çox 20 simvoldan ibarət ola bilər")
            .MinimumLength(4).WithMessage("Soyad ən çox 4 simvoldan ibarət ola bilər");
        RuleFor(x => x.ImageUrl)
            .NotNull().WithMessage("Səkil linki boş ola bilməz")
            .NotEmpty().WithMessage("Səkil linki boş ola bilməz");
        RuleFor(x => x.ImageUrl)
            .NotNull().WithMessage("Səkil linki boş ola bilməz")
            .NotEmpty().WithMessage("Səkil linki boş ola bilməz");
        RuleFor(x => x.Specialization)
            .NotNull().WithMessage("Sahə boş ola bilməz")
            .NotEmpty().WithMessage("Sahə boş ola bilməz");
        RuleFor(x => x.Biography)
            .NotNull().WithMessage("Məlumat hissəsi boş ola bilməz")
            .NotEmpty().WithMessage("Məlumat hissəsi boş ola bilməz");
        RuleFor(x => x.Experience)
            .NotNull().WithMessage("Təcrübə boş ola bilməz")
            .NotEmpty().WithMessage("Təcrübə boş ola bilməz");
        RuleFor(x => x.Age)
            .NotNull().WithMessage("Yaş boş ola bilməz")
            .NotEmpty().WithMessage("Yaş boş ola bilməz")
            .InclusiveBetween(18,65).WithMessage("Yaş 18 ilə 65 arasında olmalıdır");
        RuleFor(x => x.Weight)
            .NotNull().WithMessage("Çəki boş ola bilməz")
            .NotEmpty().WithMessage("Çəki boş ola bilməz")
            .InclusiveBetween(20,150).WithMessage("Çəki 20kq ilə 150kq arasında olmalıdır");
        
    }
}