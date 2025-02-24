using FitnessApp.Service.DTOs.Product;

namespace FitnessApp.Service.Service.Interface.Cart;

public interface ICartItemsService
{
    Task RemoveFromCartAsync(int productId, string userId);
    Task ClearCartAsync(string userId);
    Task<ICollection<GetCartDto>> GetCartAsync(string userId);
    Task Create(string userId, int productId, int quantity);
    Task UpdateCartAsync(int productId, string userId, int quantity);
}