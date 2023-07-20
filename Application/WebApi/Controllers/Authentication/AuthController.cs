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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Text;

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

		[AllowAnonymous]
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

		[AllowAnonymous]
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
			var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				_configuration["Jwt:Issuer"],
				_configuration["Jwt:Audience"],
				null,
				expires: DateTime.Now.AddMinutes(5),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}

