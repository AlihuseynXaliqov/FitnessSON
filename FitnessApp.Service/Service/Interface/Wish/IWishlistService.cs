using FitnessApp.Service.DTOs.Product;

namespace FitnessApp.Service.Service.Interface.Wish;

public interface IWishlistService
{
    Task<ICollection<GetProductDto>> GetWishlist(string userId);
    Task Create(string userId, int productId);
    Task RemoveFromWishlistAsync(int productId, string userId);
}