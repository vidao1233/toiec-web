﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using toiec_web.Models;
using toiec_web.Services;
using toiec_web.Services.IService;
using toiec_web.ViewModels.User;

namespace toiec_web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseAPIController
    {
        private readonly ToiecDbContext _dbContext;
        private readonly UserManager<Users> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IProfessorService _professorService;
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public AdminController(ToiecDbContext dbContext, UserManager<Users> userManager,
            IMapper mapper, RoleManager<IdentityRole> roleManager, IEmailService emailService,
            IProfessorService professorService, IAdminService adminService, IUserService userService)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _emailService = emailService;
            _professorService = professorService;
            _adminService = adminService;
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var usersList = await _userManager.Users.ToListAsync();
            return Ok(usersList);
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            var userView = _mapper.Map<UserViewModel>(user);
            return Ok(userView);
        }

        [HttpGet]
        [Route("GetUsersByRole")]
        public async Task<IActionResult> GetUsersByRole (string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
                return Ok(usersInRole);
            }
            // Role not found, handle accordingly
            return StatusCode(StatusCodes.Status404NotFound,
                        new Response { Status = "Error", Message = "Role not found." });
        }

        [HttpPost]
        [Route("Register-Professor-Admin")]
        public async Task<IActionResult> Register([FromBody] SignUp signUp, string role)
        {

            //check user if exist
            var userExist = await _userManager.FindByEmailAsync(signUp.Email);

            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User already exists!" });
            }

            //Add the User in the database
            var user = new Users()
            {
                Fullname = signUp.FullName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = signUp.Email,
                UserName = signUp.Username
            };

            //check role if exist
            if (await _roleManager.RoleExistsAsync(role))
            {
                //create user
                var result = await _userManager.CreateAsync(user, signUp.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = $"Error: {error.Description}" });
                    }
                }

                //check if user == null
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        new Response { Status = "Error", Message = "User not found." });
                }

                //check if role == null
                if (string.IsNullOrEmpty(role))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "Role is null or empty." });
                }

                //Add role to the user
                await _userManager.AddToRoleAsync(user, role);

                ////Add Token to Verify the email...
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);                

                ////send email confirm
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authen", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email! }, "Confirmation email link", confirmationLink!);
                _emailService.SendEmail(message);

                //create Professor into database
                if (role == "Professor")
                {
                    await _professorService.AddProfessor(user.Id);
                }
                if(role == "Admin")
                {
                    await _adminService.AddAdmin(user.Id);
                }
                await _dbContext.SaveChangesAsync();

                //when success
                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"User created & email sent to {user.Email} Successfully." });
            }
            else
            {
                Console.WriteLine("error");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "This Role Does Not Exist." });
            }
        }

        [HttpPut]
        [Route("ResetPassword/{email}")]
        public async Task<IActionResult> ResetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email should not be null or empty");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            // Generate a new password for the user (you can implement your own password generation logic)
            string newPassword = "NewPass@123";

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (!result.Succeeded)
            {
                return BadRequest("Failed to reset the password");
            }

            // Send the new password to the user's email (optional)
            var message = new Message(new string[] { user.Email }, "Password Reset", $"Your new password: {newPassword}");
            _emailService.SendEmail(message);
            
            return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"Password reset successfully!" });
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new Response { Status = "Error", Message = $"User does not exist" });
            }
            var _user = await _userManager.FindByIdAsync(id.ToString());

            var result = await _userManager.DeleteAsync(_user);

            return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"User was deleted!" });
        }

        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = "Email Verified Successfully" });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                   new Response { Status = "Error", Message = "This User Does Not Exist" });
        }


    }
}
