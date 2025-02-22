using FitnessApp.Core.Cart;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class CartItemsRepository:Repository<CartItem>,ICartItemsRepository
{
    public CartItemsRepository(AppDbContext context) : base(context)
    {
    }
}