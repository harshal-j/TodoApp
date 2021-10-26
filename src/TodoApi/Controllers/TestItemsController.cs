using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestItemsController : Controller
    {
        private readonly IConfiguration _configuration;

        public TestItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("Todos")]
        public List<Todo> Get()
        {
            return new List<Todo>()
            {
                new Todo
                {
                    Id = 1,
                    Description = this._configuration.GetValue<string>("mysql:client:database")
                }
            };
        }
    }
}
