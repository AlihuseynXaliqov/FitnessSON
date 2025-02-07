using AutoMapper;
using FitnessApp.Core;
using FitnessApp.Service.DTOs.Trainer;

namespace FitnessApp.Service.Mapper.Trainer;

public class TrainerProfile : Profile
{
    public TrainerProfile()
    {
        // Mapping for creating a trainer

        CreateMap<CreateTrainerDto, Core.Trainer>()
            .ForMember(dest => dest.TrainersClasses, opt =>
                opt.MapFrom(src => src.ClassIds.Select(id => new TrainersClasses { ClassId = id })));

        // Add the missing reverse mapping:
        CreateMap<Core.Trainer, CreateTrainerDto>()
            .ForMember(dest => dest.ClassIds, opt =>
                opt.MapFrom(src => src.TrainersClasses.Select(tc => tc.ClassId)));

        // Other mappings
        CreateMap<Core.Trainer, GetTrainerDto>()
            .ForMember(dest => dest.ClassIds, opt =>
                opt.MapFrom(src => src.TrainersClasses.Select(tc => tc.ClassId)))
            .ReverseMap();

        CreateMap<Core.Trainer, UpdateTrainerDto>()
            .ForMember(dest => dest.ClassIds, opt =>
                opt.MapFrom(src => src.TrainersClasses.Select(tc => tc.ClassId)))
            .ReverseMap();
    }
}