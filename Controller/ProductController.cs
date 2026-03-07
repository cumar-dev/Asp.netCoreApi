using Microsoft.AspNetCore.Mvc;
using ECOMMERCE.Model;
namespace ECOMMERCE.Model
{

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
     private static List<Product> products = new List<Product>
     {
         new Product
         {
            Id = 1,
            Name = "Apple Watch",
            Description = "Apple watch is a watch that production by Apple company",
            Price = 250,
            Stock = 10,
            CategoryId = 01010,
            CreatedAt = DateTime.Now
            }
     };
    [HttpGet]
    public IActionResult Get()
        {

            return Ok(products);
        }
    [HttpPost]

    public IActionResult Post([FromBody] Product newProduct)
        {
            if(newProduct == null)
            {
                return BadRequest("product must be get");
            }
            newProduct.Id = products.Count + 1;
            newProduct.CreatedAt = DateTime.Now;
            products.Add(newProduct);
            return Ok(products);
        }
    [HttpPut("{id}")]

    public IActionResult Put(int id,[FromBody] Product newProduct)
        {
            var updatedProduct = products.FirstOrDefault(product => product.Id == id);
            if(updatedProduct == null)
            {
                return NotFound("there is no get a product we please fill....");
            }
            updatedProduct.Name = newProduct.Name;
            updatedProduct.Price = newProduct.Price;
            updatedProduct.CategoryId = newProduct.CategoryId;
            updatedProduct.Description = newProduct.Description;
            updatedProduct.CreatedAt = newProduct.CreatedAt;
            return Ok(updatedProduct);
        }    

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var deletingProduct = products.FirstOrDefault(product => product.Id == id);
            if(deletingProduct == null)
            {
                return NotFound("there is no product to delete it....");
            }
            products.Remove(deletingProduct);
            return Ok("Product deleted successfully");
        }
}
}