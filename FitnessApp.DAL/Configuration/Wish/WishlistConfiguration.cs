using FitnessApp.Core.Wish;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration.Wish;

public class WishlistConfiguration:IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder.HasOne(x => x.Product)
            .WithMany(x => x.wishlists)
            .HasForeignKey(x => x.ProductId);
        
        builder.HasOne(x => x.User)
            .WithMany(x=>x.Wishlists)
            .HasForeignKey(x => x.UserId);
    }
}