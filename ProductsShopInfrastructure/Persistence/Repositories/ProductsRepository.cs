using Microsoft.EntityFrameworkCore;
using ProductsShop.Domain.Entities;
using ProductsShopApplication.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShopInfrastructure.Persistence.Repositories
{
    internal class ProductsRepository(ApplicationDbContext context) : IProductsRepository
    {
        public async Task Add(Product product)
        {
            context.Add(product);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Exists(string name)
        {
            return await context.Products.AnyAsync(X => X.Name == name);
        }
    }
}
