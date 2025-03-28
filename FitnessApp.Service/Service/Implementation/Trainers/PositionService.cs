﻿using AutoMapper;
using FitnessApp.Core.Trainer;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Position;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Helper.Exception.Position;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Trainers;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation.Trainers;

public class PositionService : IPositionService
{
    private readonly IPositionRepository _repository;
    private readonly IMapper _mapper;

    public PositionService(IPositionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreatePositionDto> CreateAsync(CreatePositionDto dto)
    {
        var position = _repository.Table.AsNoTracking()
            .FirstOrDefault(p => p.Name == dto.Name);

        if (position != null)
        {
            if (position.IsDeleted)
            {
                position.IsDeleted = false;
                _repository.Update(position);
                await _repository.SaveChangesAsync();
            }
            else
            {
                throw new PositionException("Hal hazirda bu position movcuddur", 404);
            }
        }
        else
        {
            var newPosition = _mapper.Map<TrainerPosition>(dto);
            await _repository.AddAsync(newPosition);
            await _repository.SaveChangesAsync();
        }

        return _mapper.Map<CreatePositionDto>(dto);
    }

    public async Task<GetPositionDto> GetByIdAsync(int Id)
    {
        if (Id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);
        var position = await _repository.GetByIdAsync(Id);
        if (position == null) throw new NotFoundException("Position Tapilmadi", 404);
        return _mapper.Map<GetPositionDto>(position);
    }

    public async Task DeleteAsync(int Id)
    {
        var oldPosition = await GetByIdAsync(Id);
        var position = _mapper.Map<TrainerPosition>(oldPosition);
        _repository.SoftDelete(position);
        await _repository.SaveChangesAsync();
    }

    public async Task<UpdatePositionDto> UpdateAsync(UpdatePositionDto dto)
    {
        if (dto.Id <= 0) throw new NegativeIdException("Id menfi və ya sıfır ola bilməz", 404);

        var oldPosition = await _repository.GetAll().FirstOrDefaultAsync(p => p.Id == dto.Id);
        if (oldPosition == null) throw new NotFoundException("Position Tapılmadı", 404);

        var existingPosition = await _repository.GetAll().FirstOrDefaultAsync(x => x.Name == dto.Name);
    
        if (existingPosition != null)
        {
            if (existingPosition.IsDeleted)
            {
                existingPosition.IsDeleted = false;
                _repository.Update(existingPosition);
            }
            else
            {
                throw new PositionException("Hal-hazırda bu position mövcuddur", 404);
            }
        }

        _mapper.Map(dto, oldPosition);
        _repository.Update(oldPosition);
        await _repository.SaveChangesAsync();
    
        return _mapper.Map<UpdatePositionDto>(oldPosition);
    }

    public ICollection<GetPositionDto> GetAll()
    {
        var positions =_repository.GetAll();
        return _mapper.Map<ICollection<GetPositionDto>>(positions);
    }
}