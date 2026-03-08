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
          Id = 1,
          Name = "Electronics",
          Description = "Devices and gadgets"
      },
      new Category
      {
          Id = 2,
          Name = "Clothing",
          Description = "Men and women clothes"
      },
      new Category
      {
          Id = 3,
          Name = "Books",
          Description = "Educational and story books"
      },
      new Category
      {
          Id = 4,
          Name = "Food",
          Description = "Groceries and meals"
      },
      new Category
      {
          Id = 5,
          Name = "Sports",
          Description = "Sports equipment"
      }  
    };
    [HttpGet]
    public IActionResult Get()
    {
       return Ok(category);
    }

    [HttpPost]

    public IActionResult Post([FromBody] Category listCategory)
        {
            if(listCategory == null)
            {
                return BadRequest("there is no get any category");
            }
            listCategory.Id = category.Count + 1;
            category.Add(listCategory);
            return Ok("category get successfully");
        }

    [HttpPut("{id}")]
    
    public IActionResult Put(int id,[FromBody] Category newCategory)
        {
            var categories = category.FirstOrDefault(selectedCategory => selectedCategory.Id == id);
            if(categories == null)
            {
                return NotFound("category not get please fill....");
            }

            categories.Name = newCategory.Name;
            categories.Description = newCategory.Description;
            return Ok(categories);
        }   
    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
        {
            var categories = category.FirstOrDefault(categoryDeleting => categoryDeleting.Id == id);
            if(categories == null)
            {
                return NotFound("category need to delet not get please fill...");
            }
            category.Remove(categories);
            return Ok("category Deleted successfully");
        }    
}
}