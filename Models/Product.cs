namespace assessment_kelvin.Models;
using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    [Url]
    public string? Image { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public decimal Price { get; set; }
}
