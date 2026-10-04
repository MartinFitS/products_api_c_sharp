using Microsoft.AspNetCore.Mvc;
using ProductsShop.Domain.Entities.ValueObjects;
using ProductsShopApplication.TestCases.Products.Commands.CreateProduct;
using ProductsShopWebApi.DTOs;
using ProductsShopApplication.Utilities.Mediator;

namespace ProductsShopWebApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromBody] CreateProductDTO model)
    {
        var command = new CreateProductCommand(
            Name: model.Name,
            Description: model.Description,
            Price: model.Price,
            Currency: model.Currency,
            InitialInventory: model.InitialInventory
            );

        var id = await mediator.Send(command);

        return id;
    }
}
