using CRUD.API.Models;
using CRUD.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.Tokens;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<User> users = null;
            try
            {
                users = _userService.GetUsers();
            }
            catch (Exception ex) { }
            if (users == null) return NotFound();
            return Ok(users);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            if (_userService.GetUserById(id) != null)
            {
                return Ok(_userService.GetUserById(id));
            }
            return BadRequest("User Id not found");
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(User user)
        {
            if(_userService.AddUser(user))
            {
                return Ok("User added");
            }
            return BadRequest("User sign up failed");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(User user)
        {
            try
            {
                if(_userService.UpdateUser(user))
                    return Ok("Details updated");
            }
            catch (Exception ex) { }
            return BadRequest("Details update failed");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if(_userService.GetUserById(id) != null)
            {
                if(_userService.DeleteUser(id))
                    return Ok("User deleted");
            }
            return BadRequest("User delete failed");
        }
    }
}
