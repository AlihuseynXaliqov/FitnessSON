using FitnessApp.Service.DTOs.Product;

namespace FitnessApp.Service.Service.Interface;

public interface IProductService
{
    Task<CreateProductDto> Create(CreateProductDto dto);
    
}