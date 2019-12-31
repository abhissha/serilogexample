using System.Collections.Generic;
using HttpContextMiddleware.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HttpContextMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILogger _logger;

        public ValuesController(
            ILogger logger,
            ITokenService tokenService)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.Information("logging information should log token information {data}", "fetch");
            return new string[] { "value1", "value2" };
        }
    }
}
