using FitnessApp.Core.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration.Products;

public class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255); // Maksimum uzunluq təyin edirik

        builder.Property(x => x.Description)
            .IsRequired(false) // Məlumat olmasa, boş qala bilər
            .HasMaxLength(1000);

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); // Qiymət üçün düzgün format

        builder.Property(x => x.Discount)
            .HasDefaultValue(0) // Əgər endirim yoxdursa, 0 olaraq qəbul edilir
            .HasColumnType("decimal(5,2)");

        builder.Property(x => x.SKU)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Rate)
            .HasDefaultValue(0); // Əgər məhsul reytinq almamışdırsa, 0 olsun

        builder.Property(x => x.StockQuantity)
            .IsRequired()
            .HasDefaultValue(0); // Stokda olmaya bilər, default 0 olsun

        builder.Property(x => x.IsOnSale)
            .HasDefaultValue(false); // Satışda olub-olmadığını təyin edirik

        builder.Property(x => x.ImageUrl)
            .IsRequired(false)
            .HasMaxLength(500); // Maksimum URL uzunluğu

        builder.Property(x => x.Size)
            .IsRequired(false); // Bəzi məhsullarda ölçü olmaya bilər

        builder.Property(x => x.Color)
            .IsRequired(false)
            .HasMaxLength(50);        
    }
}