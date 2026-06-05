using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studytracking_api.Data;
using studytracking_api.Models.Entities;
using studytracking_api.Models.DataTransferObjects;

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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserById( [FromRoute] Guid id)
        {
            var user = dbContext.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser( [FromBody] CreateUserDto UserDto)
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

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser( [FromRoute] Guid id, [FromBody] UpdateUserDto UserDto) 
        {
           var UserEntity = dbContext.User.Find(id);
            if (UserEntity == null)
            {
                return NotFound();
            }
            UserEntity.Username = UserDto.Username;
            UserEntity.Email = UserDto.Email;
            UserEntity.PasswordHash = UserDto.PasswordHash;
            UserEntity.Role = UserDto.Role;

            dbContext.SaveChanges();
            return Ok(UserEntity);
        }
    }
}
