﻿using FitnessApp.Core.Products;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class ProductRepository:Repository<Product>,IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}