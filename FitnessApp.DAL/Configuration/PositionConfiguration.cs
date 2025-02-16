using FitnessApp.Core;
using FitnessApp.Core.Trainer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration;

public class PositionConfiguration:IEntityTypeConfiguration<TrainerPosition>
{
    public void Configure(EntityTypeBuilder<TrainerPosition> builder)
    {
        builder.Property(x=>x.Name).HasMaxLength(20).IsRequired();
        builder.HasMany(x=>x.Trainers).WithOne(x=>x.Position).HasForeignKey(x=>x.PositionId);
    }
}