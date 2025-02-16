using FitnessApp.Core;
using FitnessApp.Core.Trainer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration;

public class TrainerConfiguration:IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.Property(x=>x.FirstName).HasMaxLength(20).IsRequired();
        builder.Property(x=>x.LastName).HasMaxLength(20).IsRequired();
        builder.Property(x=>x.Email).IsRequired();
        builder.Property(x=>x.ImageUrl).IsRequired();
        builder.Property(x=>x.PhoneNumber).IsRequired();
        builder.Property(x=>x.Experience).IsRequired();
        builder.Property(x=>x.Biography).IsRequired();
        builder.Property(x=>x.Age).IsRequired();
        builder.Property(x=>x.Weight).IsRequired();
        builder.Property(x=>x.PhoneNumber).IsRequired();


        builder.HasMany(t => t.TrainersClasses)
            .WithOne(tc => tc.Trainer)
            .HasForeignKey(tc => tc.TrainerId);
        
        
    }
}