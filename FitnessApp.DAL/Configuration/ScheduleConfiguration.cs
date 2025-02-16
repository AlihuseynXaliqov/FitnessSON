using FitnessApp.Core;
using FitnessApp.Core.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.HasOne(s => s.Class)
            .WithMany(c => c.Schedules)
            .HasForeignKey(s => s.ClassId);
        builder.HasOne(s => s.Trainer)
            .WithMany(t => t.Schedules)
            .HasForeignKey(s => s.TrainerId);
    }
}