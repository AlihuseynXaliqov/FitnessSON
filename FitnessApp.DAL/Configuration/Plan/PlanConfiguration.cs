using FitnessApp.Core.Plan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration.Plan;

public class PlanConfiguration:IEntityTypeConfiguration<PricingPlan>
{
    public void Configure(EntityTypeBuilder<PricingPlan> builder)
    {
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.withTrainer).IsRequired();
        builder.Property(x => x.Duration).IsRequired();
        
        builder.HasMany(x=>x.UserPlans)
            .WithOne(x=>x.Plan)
            .HasForeignKey(x=>x.PlanId);
        
        
    }
}