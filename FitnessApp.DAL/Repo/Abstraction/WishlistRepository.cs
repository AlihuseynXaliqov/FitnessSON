using FitnessApp.Core.Wish;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class WishlistRepository:Repository<Wishlist>,IWishlistRepository
{
    public WishlistRepository(AppDbContext context) : base(context)
    {
    }
}