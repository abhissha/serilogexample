using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog.Context;
using HttpContextMiddleware.Services;

namespace HttpContextMiddleware
{
    public class ClaimsMiddleware
    {
        private readonly RequestDelegate _next;

        public ClaimsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var tokens = new TokenService(context);
            var userToken = tokens.Get();
            if(userToken != null)
            {
                LogContext.PushProperty("userName", userToken.UserName);
                LogContext.PushProperty("lastName", userToken.LastName);
                LogContext.PushProperty("productName", userToken.ProductName);
            }
            
            await _next.Invoke(context);
        }
    }
}