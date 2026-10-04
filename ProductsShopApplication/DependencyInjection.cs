using Microsoft.Extensions.DependencyInjection;
using ProductsShopApplication.TestCases.Products.Commands.CreateProduct;
using ProductsShopApplication.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShopApplication;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();

        services.AddScoped<IrequestHandler<CreateProductCommand, Guid>, TestCaseCreateProduct>();

        return services;
    }
}
