using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration.Schedule;

public class ScheduleConfiguration : IEntityTypeConfiguration<Core.Class.Schedule>
{
    public void Configure(EntityTypeBuilder<Core.Class.Schedule> builder)
    {
        builder.HasOne(s => s.Class)
            .WithMany(c => c.Schedules)
            .HasForeignKey(s => s.ClassId);
        builder.HasOne(s => s.Trainer)
            .WithMany(t => t.Schedules)
            .HasForeignKey(s => s.TrainerId);
    }
}