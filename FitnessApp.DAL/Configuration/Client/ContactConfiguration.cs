using FitnessApp.Core.Contact;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration.Client;

public class ContactConfiguration:IEntityTypeConfiguration<ContactMessage>
{
    public void Configure(EntityTypeBuilder<ContactMessage> builder)
    {
        builder.Property(x=>x.Name).HasMaxLength(20).IsRequired();
        builder.Property(x=>x.Message).HasMaxLength(500).IsRequired();
        builder.Property(x=>x.Email).IsRequired();
        builder.Property(x=>x.Subject).HasMaxLength(20).IsRequired();
    }
}