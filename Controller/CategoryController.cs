using Microsoft.AspNetCore.Mvc;
namespace ECOMMERCE.Model
{
    
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private static List<Category> category = new List<Category>
    {
      new Category
      {
          
      }  
    };
    [HttpGet]
    public IActionResult Get()
    {
       return Ok(category);
    }
}
}