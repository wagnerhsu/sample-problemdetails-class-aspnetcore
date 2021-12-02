using ErrorHandlingProblemDetails.Data;

namespace ErrorHandlingProblemDetails.Infrastructure;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllPrpoducts();
    Task<Product> GetProductById(int id);
    Task CreateNewProduct(Product product);
    Task<Product> GetProductByName(string name);
    Task UpdateProduct(Product product);

    Task DeleteProduct(int id);
}