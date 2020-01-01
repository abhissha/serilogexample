using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HttpContextMiddleware.Services;
using Microsoft.AspNetCore.Mvc;

namespace HttpContextMiddleware.Controllers
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
            var fakeUserToken = TokenService.CreateFakeUser();
            var claims = new List<Claim>();
            claims.Add(new Claim("userName", fakeUserToken.UserName));
            claims.Add(new Claim("lastName", fakeUserToken.LastName));
            claims.Add(new Claim("productName", fakeUserToken.ProductName));

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
