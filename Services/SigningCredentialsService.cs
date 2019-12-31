using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleOutput.Services
{
    public interface ISigningCredentialsService
    {
        SigningCredentials Get();
    }

    public class SigningCredentialsService : ISigningCredentialsService
    {
        public IConfiguration Configuration { get; }


        public SigningCredentialsService(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public SigningCredentials Get()
        {
            var securityKey = GetKey();
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            return signingCredentials;
        }

        public SymmetricSecurityKey GetKey()
        {
            var key = Configuration.GetValue<string>("mySuperSecretKey");
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key));
            return securityKey;
        }
    }
}
