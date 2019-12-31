﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleOutput.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ConsoleOutput.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILogger _logger;
        private ITokenService _tokenService;

        public ValuesController(
            ILogger logger,
            ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.Information("logging information should log token information {data}", "fetch");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
