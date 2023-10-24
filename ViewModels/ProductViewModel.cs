using System.ComponentModel.DataAnnotations;

namespace assessment_kelvin.ViewModel;

public class ProductViewModel
{
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }

    [Display(Name = "ImageFile")]
    [DataType(DataType.Upload)]
    [Required(ErrorMessage = "Please select an image")]
    public IFormFile? ImageFile { get; set; }
}
