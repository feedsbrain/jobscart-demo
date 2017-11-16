using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using JobsCart.DTOs;
using JobsCart.Helpers;
using JobsCart.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JobsCart.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    public class LoginController : Controller
    {
        private ILoginService _loginService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public LoginController(
            ILoginService loginService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _loginService = loginService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginDto loginDto)
        {
            var customer = _loginService.Authenticate(loginDto.UserName, loginDto.Password);

            if (customer == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    // To simplified the process
                    new Claim(ClaimTypes.Name, customer.UserName.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new CustomerDto
            {
                Id = customer.Id,
                UserName = customer.UserName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Token = tokenString
            });
        }
    }
}