using AutoMapper;
using FitnessApp.Core.Products;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Product;
using FitnessApp.Service.Helper.Exception.Base;
using FitnessApp.Service.Helper.Exception.Product;
using FitnessApp.Service.Service.Interface;
using FitnessApp.Service.Service.Interface.Products;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service.Service.Implementation.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<CreateProductDto> Create(CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CreateProductDto>(product);
    }

    public async Task<GetProductDto> GetById(int id)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);

        var product = await _repository.GetAll("Category", "ProductImages",
                "TagProducts", "TagProducts.Tag")
            .FirstOrDefaultAsync(x => x.Id == id);
        if (product == null) throw new NotFoundException("Bele mehsul movcud deyil", 404);

        return _mapper.Map<GetProductDto>(product);
    }

    public ICollection<GetProductDto> GetAll()
    {
        var products = _repository.GetAll("Category", "ProductImages",
            "TagProducts", "TagProducts.Tag");
        return _mapper.Map<ICollection<GetProductDto>>(products);
    }

    public async Task<UpdateProductDto> Update(UpdateProductDto dto)
    {
        var product = await _repository.GetAll("Category", "ProductImages",
                "TagProducts", "TagProducts.Tag")
            .FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (product == null) throw new NotFoundException("Bele mehsul movcud deyil", 404);
        _mapper.Map(dto, product);
        _repository.Update(product);
        await _repository.SaveChangesAsync();
        return _mapper.Map<UpdateProductDto>(product);
    }

    public async Task Delete(int id)
    {
        var product = await _repository.GetAll("Category", "ProductImages",
                "TagProducts", "TagProducts.Tag")
            .FirstOrDefaultAsync(x => x.Id == id);
        if (product == null) throw new NotFoundException("Bele mehsul movcud deyil", 404);
        _repository.Delete(product);
        await _repository.SaveChangesAsync();
    }

    public async Task<string> IncreaseStock(int id, int quantity)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);

        var product = await _repository.GetAll("Category", "ProductImages",
                "TagProducts", "TagProducts.Tag")
            .FirstOrDefaultAsync(x => x.Id == id);
        if (product == null) throw new NotFoundException("Bele mehsul movcud deyil", 404);
        
        product.StockQuantity += quantity;
        _repository.Update(product);
        await _repository.SaveChangesAsync();
        return $"{@quantity} adad mehsul elave olundu";
    }
    
    public async Task<string> ReduceStock(int id, int quantity)
    {
        if (id <= 0) throw new NegativeIdException("Id menfi ve ya sifir ola bilmez", 404);

        var product = await _repository.GetAll("Category", "ProductImages",
                "TagProducts", "TagProducts.Tag")
            .FirstOrDefaultAsync(x => x.Id == id);
        if (product == null) throw new NotFoundException("Bele mehsul movcud deyil", 404);

        if (product.StockQuantity < quantity)
        {
            throw new ProductException("Stokda kifayət qədər məhsul yoxdur",400);
        }
        product.StockQuantity -= quantity;
        _repository.Update(product);
        await _repository.SaveChangesAsync();
        return $"{@quantity} adad mehsul cixarildi";
    }
    
}