using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using toiec_web.Models;
using toiec_web.Services;
using toiec_web.ViewModels.User;

namespace toiec_web.Controllers
{
    public class UserController : BaseAPIController
    {
        private readonly UserService _userService;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Users> _signManager;
        private readonly ToiecDbContext _dbContext;

        public UserController(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<Users> signInManager, ToiecDbContext dbContext, UserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signInManager;
            _dbContext = dbContext;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var userList = await _userService.GetAllUsers();
            if (userList == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(userList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id) 
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(user);
        }

        [HttpPost] 
        public async Task<IActionResult> AddUser(UserViewModel model)
        {
            if (model == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var responde = await _userService.AddUser(model);
            if (responde == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UserViewModel model, string id)
        {
            var respond = await _userService.UpdateUser(model, id);
            if (respond == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var respond = await _userService.DeleteUser(id);
            if (respond == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
