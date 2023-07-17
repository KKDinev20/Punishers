using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using BussinessLogicLayer;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApi.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
        private IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpPost]
		[Route("register")]
		public async Task<ActionResult<User>> Register(UserDto request)
		{
			User user = new();

			user.Username = request.Username;
			user.Email = request.Email;
			user.Password = Hashing.HashPassowrd(request.Password);
			DataAccessLayer.Repositories.UserRepository.CreateUser(user);
			return Ok(user);
		}

		[HttpPost]
		[Route("login")]
		public async Task<ActionResult<string>> Login(string username, string password)
		{
			User user = UserRepository.GetUserByUsername(username);

			if (!Hashing.ValidatePassword(password, user.Password))
			{
				return BadRequest("Wrong password!");
			}
			string token = CreateToken(user);
			return Ok(token);
		}

        private string CreateToken(User user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Username)
			};

			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
				_configuration.GetSection("AppSettings:Token").Value));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: creds
				);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}
	}
}

