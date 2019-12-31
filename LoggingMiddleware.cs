using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleOutput
{
        public static class MiddlewareExtensions
        {
            public static IApplicationBuilder UseClaimsMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<ClaimsMiddleware>();
            }
        }
}
