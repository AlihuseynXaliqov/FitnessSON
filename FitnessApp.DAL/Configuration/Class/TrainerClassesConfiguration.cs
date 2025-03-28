﻿using FitnessApp.Core.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration.Class;

public class TrainerClassesConfiguration:IEntityTypeConfiguration<TrainersClasses>
{
    public void Configure(EntityTypeBuilder<TrainersClasses> builder)
    {
        builder.HasOne(x => x.Trainer).WithMany(x => x.TrainersClasses).HasForeignKey(x => x.TrainerId);
        builder.HasOne(x => x.Class).WithMany(x => x.TrainersClasses).HasForeignKey(x => x.ClassId);
        
    }
}