using ProductsShopApplication.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShopApplication.TestCases.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string? Description,
    decimal Price,
    string Currency,
    int InitialInventory
) : IRequest<Guid>;
