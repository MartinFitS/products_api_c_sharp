using ProductsShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShopApplication.Contracts;

    public interface IProductsRepository
    {

        Task Add(Product product);

        Task<bool> Exists(string name);
    }

