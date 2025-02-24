using AutoMapper;
using FitnessApp.Core.Cart;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Product;
using FitnessApp.Service.Helper.Exception.Auth;
using FitnessApp.Service.Service.Interface.Cart;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation.Cart;

public class CartItemsService : ICartItemsService
{
    private readonly ICartItemsRepository _repository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CartItemsService(ICartItemsRepository repository, IProductRepository productRepository,IMapper mapper)
    {
        _repository = repository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task Create(string userId, int productId, int quantity)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null) throw new NotFoundException("Mehsul tapilmadi", 400);

        var cartItems = _repository.GetAll().Where(x => x.UserId == userId && x.ProductId == productId)
            .FirstOrDefault();
        if (cartItems is not null)
        {
            cartItems.Quantity += quantity;
        }
        else
        {
            var cart = new CartItem()
            {
                ProductId = productId,
                UserId = userId,
                Quantity = quantity
            };
            await _repository.AddAsync(cart);
          
        }
        await _repository.SaveChangesAsync();
    }

    public async Task<ICollection<GetCartDto>> GetCartAsync(string userId)
    {
        var cartItems = await _repository.GetAll()
            .Where(c => c.UserId == userId)
            .Include(c => c.Product)  
            .ToListAsync();
        
        var cartDto = cartItems.Select(c => new GetCartDto()
        {
            Id = c.ProductId,
            Name = c.Product.Name, 
            Price = c.Product.Price,
            Quantity = c.Quantity,
            DiscountPrice = c.Product.DiscountPrice,
            Discount = c.Product.Discount,
            ImageUrl = c.Product.ImageUrl
        }).ToList();

        return cartDto;
    }


    public async Task UpdateCartAsync(int productId, string userId, int quantity)
    {
        var cartItem = await _repository.GetAll()
            .Where((c => c.UserId == userId && c.ProductId == productId)).FirstOrDefaultAsync();

        if (cartItem == null)
        {
            throw new NotFoundException("Basket tapilmadi",400);
        }

        cartItem.Quantity = quantity;
         _repository.Update(cartItem);
        await _repository.SaveChangesAsync();
    }

    public async Task RemoveFromCartAsync(int productId, string userId)
    {
        var cartItem = await _repository.GetAll()
            .Where((c => c.UserId == userId && c.ProductId == productId)).FirstOrDefaultAsync();


        if (cartItem == null)
        {
            throw new NotFoundException("Basket tapilmadi",400);
        }

         _repository.Delete(cartItem);
        await _repository.SaveChangesAsync();
    }

    public async Task ClearCartAsync(string userId)
    {
        var cartItems = await _repository.GetAll().Where(c => c.UserId == userId).ToListAsync();

        if (cartItems.Any())
        {
            foreach (var cartItem in cartItems)
            {
                 _repository.Delete(cartItem);
            }

            await _repository.SaveChangesAsync();
        }
    }
}
