using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; // Liiska List<>
using System; // Waqtiga DateTime
using ECOMMERCE.Model;
using System.Data;

namespace ECOMMERCE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<Users> users = new List<Users>
        {
            new Users
            {
                Id = 1,
                FullName = "Omar Ahmed",
                Email = "omar@gmail.com",
                PasswordHash = "12345",
                Phone = "0612345678",
                Address = "Mogadishu",
                CreatedAt = DateTime.Now
            },
            new Users
            {
                Id = 2,
                FullName = "Ayaan Ali",
                Email = "ayaan@gmail.com",
                PasswordHash = "67890",
                Phone = "0611111111",
                Address = "Hargeisa",
                CreatedAt = DateTime.Now
            },
            new Users
            {
                Id = 3,
                FullName = "mohamed ali",
                Email = "mcdev",
                PasswordHash = "125678",
                Phone = "0617264351",
                Address = "kismaayo",
                CreatedAt = DateTime.Now
            }
        };

        // GET: api/users
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(users);
        }

        [HttpPost]

        public IActionResult Post([FromBody] Users newUser)
        {
            if (newUser == null)
            {
                return BadRequest("users data is required");
            }
            // Hubi in FullName iyo Email aysan madhneyn
            if (string.IsNullOrEmpty(newUser.FullName) || string.IsNullOrEmpty(newUser.Email))
            {
                return BadRequest("FullName and Email are required");
            }


            // Samee Id cusub
            newUser.Id = users.Count + 1;
            newUser.CreatedAt = DateTime.Now;

            users.Add(newUser);

            return Ok(newUser);

        }

       [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] Users newUser)

        {
            var user = users.FirstOrDefault(userupdating => userupdating.Id == id);
           if(user == null)
            {
                return NotFound("user not found");
            } 

            // UpdateRowSource fields

            user.FullName = newUser.FullName;
            user.Email = newUser.Email;
            user.PasswordHash = newUser.PasswordHash;
            user.Address = newUser.Address;
            user.Phone = newUser.Phone;

            return Ok(user);
        }
        
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)

        {
            var user = users.FirstOrDefault(userDeleting => userDeleting.Id == id);

            if(user == null)
            {
                return NotFound("user deleting not found");
            }
           
        //    deleting
            users.Remove(user);
            // return NoContent();
            return Ok("user deleted successfully");
        }
    }
}