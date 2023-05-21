using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Ngopi.AppModel;
using Ngopi.Helpers;
using Ngopi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ngopi.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private DataContext dbContext;
        IConfiguration _configuration;

        public AuthController(DataContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserModel user)
        {
            if (user != null)
            {
                var resultLoginCheck = dbContext.Users
                    .Where(e => e.Email == user.EmailId && e.Password == user.Password)
                    .FirstOrDefault();
                if (resultLoginCheck == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    user.UserMessage = "Login Success";

                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Email", user.EmailId)
                    };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);


                    user.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(user);
                }
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {

            if (dbContext.Users.Any(x => x.Email.ToLower() == model.Email.ToLower()))
                return BadRequest("Email '" + model.Email + "' is already taken");

            Guid myuuid = Guid.NewGuid();
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                Name = model.FirstName + ' ' + model.LastName,
                Password = model.Password,
                CreatedAt = DateTime.UtcNow
            };

            // save user
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return Ok(new { message = "Registration successful" });
        }
    }
}
