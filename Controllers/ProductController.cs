using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using assessment_kelvin.Data;
using assessment_kelvin.ViewModel;
using assessment_kelvin.Models;

namespace assessment_kelvin.Controllers;

public class ProductController : Controller
{
    private readonly ProductDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductController(ProductDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _context.Products.ToListAsync();
        return View(products);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Save the product information (Name, Description, Price) to the database
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };

            // Handle the uploaded image
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                // Save the image to a location or database
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                // Save the image file path to the product
                product.Image = "/images/" + uniqueFileName;
            }

            try
            {
                _context.Products.Add(product);
                _context.SaveChanges(); // Save changes to the database
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                // Handle the exception
                Console.WriteLine(ex);
                ModelState.AddModelError(string.Empty, "An error occurred while saving the product.");
                return View(model);
            }
        }

        return View(model);
    }


    // Response JSON ----------------------------------------------

    [HttpGet]
    public JsonResult List()
    {
        var products = _context.Products.ToList();
        return Json(products);
    }
}
