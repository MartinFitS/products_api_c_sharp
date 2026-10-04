using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductsShopApplication.Contracts;
using ProductsShopInfrastructure.Persistence;
using ProductsShopInfrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ProductsShopInfrastructure;

public static class DependencyInyectiontion
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

        services.AddScoped<IProductsRepository, ProductsRepository>();

        return services;
    }
}
