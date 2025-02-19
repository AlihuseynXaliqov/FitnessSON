using FitnessApp.Core.Plan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration.Plan;

public class UserPlanConfiguration:IEntityTypeConfiguration<UserPlan>
{
    public void Configure(EntityTypeBuilder<UserPlan> builder)
    {
        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.EndDate).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserPlans)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Plan)
            .WithMany(x => x.UserPlans)
            .HasForeignKey(x => x.PlanId);
    }
}