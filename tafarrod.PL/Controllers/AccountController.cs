using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tafarrod.BLL.DTOs;
using tafarrod.BLL.Repository;
using tafarrod.BLL.UnitOfWork;
using tafarrod.DAL.Entities;

namespace tafarrod.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO model )
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var user = mapper.Map<User>(model);
                    await unitOfWork.UserRepo.CreateAsync(user);
                    await unitOfWork.saveAsync();
                    return Ok(model);
                }
                     return BadRequest(model);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // For debugging, consider using a logging framework
                return BadRequest(ex.Message);

            }
        }



        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var user = await AuthenticateUserAsync(model.UserName, model.Password);
                    if (user == null)
                    {
                        return Unauthorized("Invalid username or password.");
                    }
                    var token = await GenerateToken(user);
                    return Ok(token);

                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            // Fetch user from the database by username
            var user = await unitOfWork.UserRepo.GetByUsernameAsync(username);

            if (user != null && user.Password == password) // Implement proper password hashing
            {
                return user;
            }

            return null;
        }

        private async Task<string> GenerateToken(User user)
        {

            var claims = new List<Claim>
            {
                   new Claim(ClaimTypes.Name, user.UserName),
                   new Claim(ClaimTypes.Email, user.Email)            };
            claims.Add(new Claim(ClaimTypes.Email, user.Email!));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:ValidIssuer"],
                audience: configuration["Jwt:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }

}
