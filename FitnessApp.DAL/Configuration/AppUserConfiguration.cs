﻿using FitnessApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration;

public class AppUserConfiguration:IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(x=>x.FirstName).HasMaxLength(20).IsRequired();
        builder.Property(x=>x.LastName).HasMaxLength(20).IsRequired();
        builder.HasMany(x=>x.ClientFeedBacks).WithOne(x=>x.User).HasForeignKey(x=>x.UserId);

    }
}