using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using toiec_web.Data;
using toiec_web.Helper;
using toiec_web.Models;
using toiec_web.Services;
using toiec_web.Services.IService;
using toiec_web.ViewModels.Authentication;
using toiec_web.ViewModels.User;

namespace toiec_web.Controllers
{
    public class AuthenController : BaseAPIController
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Users> _signManager;
        private readonly ToiecDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IStudentService _studentService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUploadFileService _uploadFileService;

        public AuthenController(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, 
            SignInManager<Users> signManager, ToiecDbContext dbContext, IEmailService emailService,
             IConfiguration configuration, IStudentService studentService, IAuthenticationService authenticationService,
            IUploadFileService uploadFileService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signManager;
            _dbContext = dbContext;
            _configuration = configuration;
            _emailService = emailService;
            _studentService =  studentService;
            _authenticationService = authenticationService;
            _uploadFileService = uploadFileService;
        }

        [HttpPost]
        [Route("Register")]        
        public async Task<IActionResult> Register([FromBody] SignUp signUp)
        {
            //default role = Student
            string role = "Student";

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

                //create Student into database
                _studentService.AddStudent(user.Id);
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

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LogInModel loginModel)
        {
            //Checking the user
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            //Checking the password
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                //Claim list creation
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                //Add role to the list
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                //Check 2FA
                if (user.TwoFactorEnabled)
                {
                    await _signManager.SignOutAsync();
                    await _signManager.PasswordSignInAsync(user, loginModel.Password, false, true);
                    var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

                    var message = new Message(new string[] { user.Email! }, "OTP Confrimation", token);
                    _emailService.SendEmail(message);

                    return StatusCode(StatusCodes.Status200OK,
                     new Response { Status = "Success", Message = $"We have sent an OTP to your Email {user.Email}" });
                }
                //generate the token with claim
                var jwtToken = GetToken(authClaims);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),                    
                    expiration = jwtToken.ValidTo,
                    user.EmailConfirmed,

                });
                //returning the token...
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Login-2FA")]
        public async Task<IActionResult> LoginWithOTP(Login2FAModel model)
        {
            //get uset
            var user = await _userManager.FindByNameAsync(model.Username);
            //enable twofacter
            user.TwoFactorEnabled = true;
            var signIn = await _signManager.TwoFactorSignInAsync("Email", model.Code, false, false);
            if (signIn.Succeeded)
            {
                if (user != null)
                {
                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                    var userRoles = await _userManager.GetRolesAsync(user);
                    foreach (var role in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var jwtToken = GetToken(authClaims);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                        expiration = jwtToken.ValidTo
                    });
                    //returning the token...
                }
            }
            return StatusCode(StatusCodes.Status404NotFound,
                new Response { Status = "Error", Message = $"Invalid Code" });
        }

        [HttpPost]
        [Route("SendForgotPasswordCode")]
        public async Task<IActionResult> SendForgotPasswordCode(string email)
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

            int otp = GenerateOTP(); 

            var resetPassword = new ResetPassword
            {
                UserId = user.Id,
                OTP = otp.ToString(),
                InsertDateTimeUTC = DateTime.UtcNow
            };

            _dbContext.ResetPasswords.Add(resetPassword);
            await _dbContext.SaveChangesAsync();

            // Send the OTP to the user's email
            var message = new Message(new string[] { user.Email }, "Reset Password OTP", $"OTP: {otp}");
            _emailService.SendEmail(message);

            return Ok(new { Status = "Success", Message = "OTP sent successfully" });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ResetPasswordModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.OTP) || string.IsNullOrEmpty(model.NewPassword))
            {
                return BadRequest("Email, OTP, and New Password should not be null or empty");
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var resetPasswordDetails = await _dbContext.ResetPasswords
                .Where(rp => rp.OTP == model.OTP && rp.UserId == user.Id)
                .OrderByDescending(rp => rp.InsertDateTimeUTC)
                .FirstOrDefaultAsync();

            if (resetPasswordDetails == null)
            {
                return BadRequest("Invalid OTP");
            }

            // Verify if OTP is expired (15 minutes in this example)
            if (resetPasswordDetails.InsertDateTimeUTC.AddMinutes(15) < DateTime.UtcNow)
            {
                return BadRequest("OTP is expired, please request a new one");
            }

            // Reset the user's password
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest("Failed to reset the password");
            }

            // Delete the used OTP from the database
            //_dbContext.ResetPasswords.Remove(resetPasswordDetails);
            //await _dbContext.SaveChangesAsync();

            return Ok(new { Status = "Success", Message = $"Password reset successfully! Your new password: {model.NewPassword}" });
        }

        [Authorize]
        [HttpPut]
        [Route("Update-Profile")]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfileModel model)
        {
            // Get the current user
            var userName = HttpContext.User.Identity.Name;
            var userId = await _authenticationService.GetCurrentUserId(userName);
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                // Handle the case when the user is not found
                return StatusCode(StatusCodes.Status404NotFound,
                    new Response { Status = "Error", Message = "User does not exist" });
            }

            // Update user's profile properties with the provided values
            user.PhoneNumber = model.PhoneNumber;
            user.Fullname = model.FullName;
            user.DateOfBirth = model.DateOfBirth.ToString();
            user.TwoFactorEnabled = model.Enable2FA;

            var image = await _uploadFileService.AddFileAsync(model.ImageURL);

            user.ImageURL = image.Url.ToString();

            IdentityResult result = await _userManager.UpdateAsync(user);
            await _dbContext.SaveChangesAsync();

            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = "Profile updated successfully!" });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "Failed to update profile." });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new Response { Status = "Error", Message = $"User does not exist" });
            }
            if (string.Compare(model.NewPassword, model.ConfirmPassword) != 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = $"The new password and the password confirm do not match." });
            }
            var resetPassResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!resetPassResult.Succeeded)
            {
                var errors = new List<string>();
                foreach (var error in resetPassResult.Errors)
                {
                    errors.Add(error.Description);
                }
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = string.Join(", ", errors) });
            }
            return Ok(new Response { Status = "Success", Message = "Password successfully changed" });
        }

        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<IActionResult> GetIdCurrent()
        {
            var userName = HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                return Ok(user);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }

        [Authorize]
        [HttpGet("CurrentRole")]
        public async Task<IActionResult> GetRoleCurrent()
        {
            var userName = HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            var userRole = await _userManager.GetRolesAsync(user);
            if (user != null)
            {
                return Ok(new { role = userRole });
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return Ok();
        }

        private static int GenerateOTP()
        {
            // Create an instance of the Random class
            Random random = new Random();

            // Generate a random 6-digit OTP (from 100000 to 999999)
            int otp = random.Next(100000, 999999);

            // Convert the OTP to a string and return it
            return otp;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT: ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
    }
}
