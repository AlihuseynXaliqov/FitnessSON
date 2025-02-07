﻿using AutoMapper;
using FitnessApp.Core;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Trainer;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Helper.Exception.Trainer;
using FitnessApp.Service.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation;

public class TrainerService : ITrainerService
{
    private readonly IMapper _mapper;
    private readonly ITrainerRepository _repository;

    public TrainerService(IMapper mapper, ITrainerRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateTrainerDto> CreateTrainerAsync(CreateTrainerDto dto)
    {
        var trainer = _mapper.Map<Trainer>(dto);
        await _repository.AddAsync(trainer);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CreateTrainerDto>(trainer);
    }

    public async Task<GetTrainerDto> GetTrainerByIdAsync(int Id)
    {
        if (Id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var trainer = await _repository.GetAll("TrainersClasses", "TrainersClasses.Class").AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == Id);
        return _mapper.Map<GetTrainerDto>(trainer);
    }

    public ICollection<GetTrainerDto> GetTrainers()
    {
        var trainers = _repository.GetAll("TrainersClasses", "TrainersClasses.Class");
        return _mapper.Map<ICollection<GetTrainerDto>>(trainers);
    }

    public async Task<UpdateTrainerDto> UpdateTrainerAsync(UpdateTrainerDto dto)
    {
        if (dto.Id <= 0)
        {
            throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        }

        var trainer = await _repository.GetAll("TrainersClasses")
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (trainer == null) throw new TrainerException("Məşqçi tapılmadı", 404);

        _mapper.Map(dto, trainer);

        trainer.TrainersClasses.Clear();
        trainer.TrainersClasses = dto.ClassIds.Select(classId => new TrainersClasses
        {
            ClassId = classId,
            TrainerId = trainer.Id
        }).ToList();

        _repository.Update(trainer);
        await _repository.SaveChangesAsync();

        return _mapper.Map<UpdateTrainerDto>(trainer);
    }

    public async Task Delete(int Id)
    {
        var trainer = await GetTrainerByIdAsync(Id);
        var oldTrainer=_mapper.Map<Trainer>(trainer);
        _repository.Delete(oldTrainer);
        await _repository.SaveChangesAsync();
    }
}