using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace HttpContextMiddleware.Services
{
    public interface ITokenService
    {
        UserToken Get();
    }

    public class UserToken
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string ProductName { get; set; }
    }

    public class TokenService : ITokenService
    {
        private HttpContext _httpContext;
        public TokenService(IHttpContextAccessor contextAccesor)
        {
            _httpContext = contextAccesor.HttpContext;
        }

        public TokenService(HttpContext context)
        {
            _httpContext = context;
        }

        public UserToken Get()
        {
            var jwt = _httpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(jwt)) return null;

            var handler = new JwtSecurityTokenHandler();
            var tokens = handler.ReadToken(jwt.ToString().Replace("Bearer ", "")) as JwtSecurityToken;
            var userName = tokens.Claims.FirstOrDefault(claim => claim.Type == "userName").Value;
            var lastName = tokens.Claims.FirstOrDefault(claim => claim.Type == "lastName").Value;
            var productName = tokens.Claims.FirstOrDefault(claim => claim.Type == "productName").Value;
            return new UserToken()
            {
                UserName = userName,
                LastName = lastName,
                ProductName = productName
            };
        }
    }
}
