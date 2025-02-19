using FitnessApp.Core.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration.Products;

public class ProductTagConfiguration : IEntityTypeConfiguration<TagProduct>
{
    public void Configure(EntityTypeBuilder<TagProduct> builder)
    {
        builder.HasOne(x => x.Product)
            .WithMany(x => x.TagProducts)
            .HasForeignKey(x => x.ProductId);
        
        builder.HasOne(x => x.Tag)
            .WithMany(x => x.TagProducts)
            .HasForeignKey(x => x.TagId);
    }
}