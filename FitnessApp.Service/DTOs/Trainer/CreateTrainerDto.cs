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
    
    
    
    public List<int> ClassIds { get; set; } = new List<int>();
}

public class CreateTrainerValidator : AbstractValidator<CreateTrainerDto>
{
    public CreateTrainerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ad boş ola bilməz")
            .MinimumLength(4).WithMessage("Ad ən azı 4 simvoldan ibarət olmalıdır")
            .MaximumLength(20).WithMessage("Ad ən çox 20 simvoldan ibarət ola bilər");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Soyad boş ola bilməz")
            .MinimumLength(4).WithMessage("Soyad ən azı 4 simvoldan ibarət olmalıdır")
            .MaximumLength(20).WithMessage("Soyad ən çox 20 simvoldan ibarət ola bilər");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Şəkil linki boş ola bilməz")
            .Must(BeAValidUrl).WithMessage("Şəkil linki düzgün formatda deyil");

        RuleFor(x => x.Specialization)
            .NotEmpty().WithMessage("Sahə boş ola bilməz");

        RuleFor(x => x.Biography)
            .NotEmpty().WithMessage("Məlumat hissəsi boş ola bilməz");

        RuleFor(x => x.Experience)
            .NotEmpty().WithMessage("Təcrübə boş ola bilməz");

        RuleFor(x => x.Age)
            .InclusiveBetween(18, 65).WithMessage("Yaş 18 ilə 65 arasında olmalıdır");

        RuleFor(x => x.Weight)
            .InclusiveBetween(20, 150).WithMessage("Çəki 20kq ilə 150kq arasında olmalıdır");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş ola bilməz")
            .EmailAddress().WithMessage("Email düzgün formatda deyil");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon nömrəsi boş ola bilməz")
            .Matches(@"^(?:\+994|0)\d{9}$").WithMessage("Telefon nömrəsi düzgün formatda deyil");

        RuleFor(x => x.FacebookUrl)
            .Must(BeAValidUrl).When(x => !string.IsNullOrWhiteSpace(x.FacebookUrl))
            .WithMessage("Facebook linki düzgün formatda deyil");

        RuleFor(x => x.InstagramUrl)
            .Must(BeAValidUrl).When(x => !string.IsNullOrWhiteSpace(x.InstagramUrl))
            .WithMessage("Instagram linki düzgün formatda deyil");

        RuleFor(x => x.TwitterUrl)
            .Must(BeAValidUrl).When(x => !string.IsNullOrWhiteSpace(x.TwitterUrl))
            .WithMessage("Twitter linki düzgün formatda deyil");
    }

    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}