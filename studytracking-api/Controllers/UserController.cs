using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studytracking_api.Data;
using studytracking_api.Models.Entities;
using studytracking_api.Models;

namespace studytracking_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = dbContext.User.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto UserDto)
        {
            var UserEntity = new User()
            {
               Username = UserDto.Username,
               Email = UserDto.Email,
               PasswordHash = UserDto.PasswordHash,
               Role = UserDto.Role
            };

            dbContext.User.Add(UserEntity);
            dbContext.SaveChanges();

            return Ok(UserEntity);
        }
    }
}
