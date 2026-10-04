using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShopInfrastructure.Persistence.Configs;

    internal class ProductConfig: IEntityTypeConfiguration<Product>
    {
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.Property(prop => prop.Name)
        .HasMaxLength(200)
        .IsRequired();

        builder.HasIndex(prop => prop.Name).IsUnique();

        builder.Property(x => x.Description)
            .HasMaxLength(2000);

        builder.ComplexProperty(prop => prop.Price, action =>
        {
            action.Property(e => e.Amount).HasColumnName("Price").HasPrecision(18, 2);
            action.Property(e => e.Currency).HasColumnName("Currency");
        });

        builder.ComplexProperty(prop => prop.InventoryQuantity, action =>
        {
            action.Property(e => e.Value).HasColumnName("InventoryQuantity");
        });
        }
    }

