using AutoMapper;
using FitnessApp.Core.Products;
using FitnessApp.DAL.Repo.Interface;
using FitnessApp.Service.DTOs.Product;
using FitnessApp.Service.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Service.Service.Implementation;

public class ProductService:IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository,IMapper mapper)
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
}