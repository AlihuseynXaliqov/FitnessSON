using FitnessApp.Service.DTOs.Product;

namespace FitnessApp.Service.Service.Interface.Products;

public interface IProductService
{
    Task<CreateProductDto> Create(CreateProductDto dto);
    ICollection<GetProductDto> GetAll();
    Task<GetProductDto> GetById(int id);
    Task<UpdateProductDto> Update(UpdateProductDto dto);
    Task Delete(int id);
    Task<string> IncreaseStock(int id, int quantity);
    Task<string> ReduceStock(int id, int quantity);
}