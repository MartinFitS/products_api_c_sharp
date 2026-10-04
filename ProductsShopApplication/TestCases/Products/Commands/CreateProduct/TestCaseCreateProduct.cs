using ProductsShop.Domain.Entities;
using ProductsShop.Domain.Entities.Exceptions;
using ProductsShop.Domain.Entities.ValueObjects;
using ProductsShopApplication.Contracts;
using ProductsShopApplication.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShopApplication.TestCases.Products.Commands.CreateProduct;
    public class TestCaseCreateProduct(IProductsRepository productRepository) : IrequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand command)
        {

            var exists = await productRepository.Exists(command.Name);

        if (exists)
        {
            throw new NegotionRule_Exception("Product can't have same name.");
        }


        var money = Money.Create(command.Price, command.Currency);
            var inventory = InventoryQuantity.Create(command.InitialInventory);

            var product = Product.Create(
                name: command.Name,
                description: command.Description,
                price: money,
                inventoryQuantity: inventory
            );




            await productRepository.Add(product);

            return product.Id;
        }
    }

