using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Service.DTOs.Trainer;

namespace FitnessApp.Service.Mapper.Trainer;
using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Service.DTOs.Trainer;


public class TrainerProfile : Profile
{
    public TrainerProfile()
    {
        // Mapping for creating a trainer
        CreateMap<CreateTrainerDto, Core.Trainer>()
            .ForMember(dest => dest.TrainersClasses, opt =>
                opt.MapFrom(src => src.ClassIds.Select(id => new TrainersClasses { ClassId = id })));

        // Reverse mapping for CreateTrainerDto
        CreateMap<Core.Trainer, CreateTrainerDto>();

        // Mapping for GetTrainerDto
        CreateMap<Core.Trainer, GetTrainerDto>()
            .ForMember(dest => dest.ClassNames, opt =>
                opt.MapFrom(src => src.TrainersClasses.Select(tc => tc.Class != null ? tc.Class.Name : null))) // Yalnız ClassNames əlavə edildi
            .ForMember(dest => dest.PositionName, opt => 
                opt.MapFrom(src => src.Position != null ? src.Position.Name : null)) // PositionName əlavə edildi
            .ReverseMap();

        CreateMap<Core.Trainer, UpdateTrainerDto>()
            .ReverseMap();
    }
}
