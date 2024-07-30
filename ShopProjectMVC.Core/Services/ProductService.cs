using ShopProjectMVC.Core.Interfaces;
using ShopProjectMVC.Core.Models;

namespace ShopProjectMVC.Core.Services;

public class ProductService : IProductService
{
    private readonly IRepository _repository;

    public ProductService(IRepository repository)
    {
        _repository = repository;
    }

    public Task<Product> AddProduct(Product product)
    {
        return _repository.Add(product);
    }

    public Task<Order> BuyProduct(int userId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProduct(int id)
    {
        return _repository.Delete<Product>(id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _repository.GetAll<Product>();
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _repository.GetAll<Category>();
    }

    public Task<Product> GetProductById(int id)
    {
        return _repository.GetById<Product>(id);
    }

    public Task<Product> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
