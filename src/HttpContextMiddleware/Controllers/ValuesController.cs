using System;
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
            // when token is passed, below log will log claims as well as below data as additional element
            _logger.Information("log information {data}", "fetch");
            // way to destructure and log the whole object
            var @event = IntegrationEvent.CreateFake();
            _logger.Information("----- Handling integration event: {IntegrationEventId} at ({@IntegrationEvent})", @event.Id, @event);
            return new string[] { "value1", "value2" };
        }
    }

    public class IntegrationEvent
    {
        public static IntegrationEvent CreateFake()
        {
            return new IntegrationEvent()
            {
                Id= Guid.NewGuid(),
                Name = "Test Integration Event",
                CreatedTime = DateTime.UtcNow,
                Description = "Test Integration Event Description"
            };
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset CreatedTime { get; set; }

        public string Description { get; set; }
    }
}
