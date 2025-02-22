using FitnessApp.Core.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.DAL.Configuration.Cart;

public class CartItemsConfiguration:IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasOne(x=>x.User)
            .WithMany(x=>x.CartItems)
            .HasForeignKey(x=>x.UserId);
        
        builder.HasOne(x=>x.Product)
            .WithMany(x=>x.CartItems)
            .HasForeignKey(x=>x.ProductId);
    }
}