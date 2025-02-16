using FitnessApp.Core;
using FitnessApp.Core.FeedBack;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration;

public class ClientConfiguration:IEntityTypeConfiguration<ClientFeedBack>
{
    public void Configure(EntityTypeBuilder<ClientFeedBack> builder)
    {
        builder.Property(x=>x.Id).IsRequired().HasMaxLength(250);
        builder.Property(x=>x.ImageUrl).IsRequired();
    }
}