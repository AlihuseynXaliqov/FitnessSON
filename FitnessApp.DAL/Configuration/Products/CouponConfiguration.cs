﻿using FitnessApp.Core.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration.Products;

public class CouponConfiguration:IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.Code).IsUnique();

        builder.Property(c => c.Code).HasMaxLength(50);

        builder.Property(c => c.DiscountAmount).HasColumnType("decimal(18,2)");
    }
}