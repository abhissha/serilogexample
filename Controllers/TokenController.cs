using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ConsoleOutput.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ConsoleOutput.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public ISigningCredentialsService SigningCredentials { get; }

        public TokenController(ISigningCredentialsService signingCredentials)
        {
            SigningCredentials = signingCredentials;
        }


        [HttpPost("generate")]
        public ActionResult GenerateToken()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("userName", "someUserName"));
            claims.Add(new Claim("lastName", "some last Name"));
            claims.Add(new Claim("productName", "some product name"));

            var token = new JwtSecurityToken(
                issuer: "issuer",
                audience: "audience",
                expires: DateTime.Now.AddYears(5),
                signingCredentials: SigningCredentials.Get(),
                claims: claims
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
