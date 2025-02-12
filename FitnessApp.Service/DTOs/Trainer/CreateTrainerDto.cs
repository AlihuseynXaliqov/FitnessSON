using FluentValidation;

namespace FitnessApp.Service.DTOs.Trainer;

public class CreateTrainerDto
{
    public string FirstName { get; set; }  
    public string LastName { get; set; } 
    public string ImageUrl { get; set; }   
    public string Biography { get; set; }
    public int Experience { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

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
            .NotEmpty().WithMessage("Şəkil linki boş ola bilməz");

        RuleFor(x => x.Biography)
            .NotEmpty().WithMessage("Məlumat hissəsi boş ola bilməz")
            .MaximumLength(150).WithMessage("Məlumat hissəsi en cox 150 sozden ibaret olmalidi")
            .MinimumLength(5).WithMessage("Məlumat hissəsi en az 5 herfden ibaret olmalidi");

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
        
    }

}