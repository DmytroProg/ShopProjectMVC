using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopProjectMVC.Core.Interfaces;
using ShopProjectMVC.Core.Models;
using ShopProjectMVC.Core.Services;

namespace ShopProjectMVC.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
        ViewBag.Categories = productService.GetAllCategories().ToList();
    }

    public async Task<IActionResult> Index()
    {
        if(HttpContext.Session.GetString("user") == null)
        {
            return RedirectToAction("Login", "User");
        }

        var products = await _productService.GetAllAsync();
        return View(products);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = _productService.GetAllCategories().ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product, int categoryId)
    {
        product.Image = "";
        product.Category = _productService.GetAllCategories().First();
        await _productService.AddProduct(product);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetProductById(id);
        return View(product);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProduct(id);
        return RedirectToAction("Index");
    }
}

public static class TestHelper
{
    public static Task<List<Product>> GetAllAsync(this IProductService productService)
    {
        return productService.GetAll()
            .AsQueryable()
            .ToListAsync();
    }
}