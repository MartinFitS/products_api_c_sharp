using System.ComponentModel.DataAnnotations;

namespace ProductsShopWebApi.DTOs;

public class CreateProductDTO
{
    [Required]
    [MaxLength]
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public required string Currency { get; set; }
    public int InitialInventory { get; set; }

}
