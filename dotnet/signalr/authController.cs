using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace signalr
{
    public class AuthenticateController : Controller
    {
        private readonly IConfigurationRoot configuration;

        public AuthenticateController(IConfigurationRoot configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (configuration.GetSection("JWT:ServerSecret").Value));
            
            var result = new
            {
                token = GenerateToken(serverSecret)
            };
            return Ok(result);
        }

        private string GenerateToken(SecurityKey key)
        {
            var now = DateTime.UtcNow;
            var issuer = configuration["JWT:Issuer"];
            var audience = configuration["JWT:Audience"];
            var identity = new ClaimsIdentity();
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(issuer, audience, identity, now, now.Add(TimeSpan.FromHours(1)), now, signingCredentials);
            var encodedJwt = handler.WriteToken(token);
            return encodedJwt;
        }
    }

}