using AutoMapper;
using FitnessApp.Core.User;
using FitnessApp.Core.Wish;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Product;
using FitnessApp.Service.Helper.Exception.Auth;
using FitnessApp.Service.Service.Interface.Wish;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation.Wish;

public class WishlistService:IWishlistService
{
    private readonly IWishlistRepository _wishlistRepository;
    private readonly IProductRepository _productRepository;
    private readonly UserManager<AppUser> _manager;
    private readonly IMapper _mapper;

    public WishlistService(IWishlistRepository wishlistRepository,
        IProductRepository productRepository,
        UserManager<AppUser> manager,
        IMapper mapper)
    {
        _wishlistRepository = wishlistRepository;
        _productRepository = productRepository;
        _manager = manager;
        _mapper = mapper;
    }

    public async Task Create(string userId, int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null) throw new NotFoundException("Mehsul tapilmadi", 400);

        if (!await _wishlistRepository.Table.AnyAsync(w => w.UserId == userId && w.ProductId == productId))
        {
            var wishlist = new Wishlist()
            {
                UserId = userId,
                ProductId = productId
            };

            await _wishlistRepository.AddAsync(wishlist);
            await _wishlistRepository.SaveChangesAsync();
        }
    }

    public async Task RemoveFromWishlistAsync(int productId, string userId)
    {
        var wishlistItem = await _wishlistRepository.GetAll().Where(w => w.UserId == userId && w.ProductId == productId)
            .FirstOrDefaultAsync();
        if (wishlistItem == null) throw new NotFoundException("Wishlist  tapilmadi");

        _wishlistRepository.Delete(wishlistItem);
        await _wishlistRepository.SaveChangesAsync();
    }

    public async Task<ICollection<GetProductDto>> GetWishlist(string userId)
    {
        var wishlist = await _wishlistRepository.GetAll().Where(w => w.UserId == userId)
            .Include(w => w.Product)
            .ToListAsync();

        return _mapper.Map<ICollection<GetProductDto>>(wishlist.Select(w => w.Product));
    }
}