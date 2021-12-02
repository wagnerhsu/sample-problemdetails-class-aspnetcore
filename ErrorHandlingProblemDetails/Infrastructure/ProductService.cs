using ErrorHandlingProblemDetails.Data;
using Microsoft.EntityFrameworkCore;

namespace ErrorHandlingProblemDetails.Infrastructure;

public class ProductService : IProductService
{
    protected readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllPrpoducts() => await _context.Products.ToListAsync();

    public async Task<Product> GetProductById(int id) => await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

    public async Task<Product> GetProductByName(string name) => await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
    public async Task UpdateProduct(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id)
    {
        var p = _context.Products.Find(id);
        _context.Products.Remove(p);
        await _context.SaveChangesAsync();
    }

    public async Task CreateNewProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
}