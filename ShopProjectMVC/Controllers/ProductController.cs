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