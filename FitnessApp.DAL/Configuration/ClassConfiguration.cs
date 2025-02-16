using FitnessApp.Core;
using FitnessApp.Core.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration;

public class ClassConfiguration:IEntityTypeConfiguration<Classes>
{
    public void Configure(EntityTypeBuilder<Classes> builder)
    {
        builder.Property(x=>x.Name).HasMaxLength(20).IsRequired();
        builder.Property(x=>x.Description).HasMaxLength(250).IsRequired();
        builder.Property(x=>x.ImageUrl).IsRequired();
    }
}