using ErrorHandlingProblemDetails.Data;
using ErrorHandlingProblemDetails.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingProblemDetails.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> Get() => await _productService.GetAllPrpoducts();

    [HttpGet]
    [Route("ThrowProductCustomException")]
    public async Task<IActionResult> ThrowProductCustomException()
    {
        throw new ProductCustomException(Request.Path.Value);
    }
    
    [HttpGet]
    [Route("ThrowGeneralException")]
    public async Task<IActionResult> ThrowGeneralException()
    {
        throw new Exception("There was an exception while fetching the product");
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpGet("byName/{name}")]
    public async Task<ActionResult<Product>> GetByName(string name)
    {
        var product = await _productService.GetProductByName(name);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task Post([FromBody] Product product) => await _productService.CreateNewProduct(product);

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(int id, Product product)
    {
        var p = await _productService.GetProductById(id);
        if (p != null)
        {
            p.Category = product.Category;
            p.Name = product.Name;
            await _productService.UpdateProduct(p);
            return Ok();
        }
        else
            return NotFound();

    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteProduct(id);
        return Ok();
    }
}