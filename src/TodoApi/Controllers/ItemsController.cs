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
    public class ItemsController : Controller
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly TodosContext _context;

        public ItemsController(ILogger<ItemsController> logger, TodosContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("Todos")]
        public async Task<List<Todo>> Get()
        {
            return await _context.Todo.ToListAsync();
        }

        [HttpGet("Todo/{id:int}")]
        public async Task<IActionResult> GetTodo(int id)
        {
            Todo item = null;
            item = await _context.Todo
                    .Where(a => a.Id == id)
                    .FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [HttpDelete("Todo/{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            _logger.LogDebug("Delete Todo");

            Todo todo = await _context.Todo
                    .Where(a => a.Id == id)
                    .FirstOrDefaultAsync();
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //PUT: api/Items/Todo
        [HttpPut("Todo")]
        public async Task<IActionResult> UpdateTodo([FromBody] Todo todo)
        {
            _logger.LogDebug("Update Todo");

            var existingTodo = await _context.Todo
                    .Where(a => a.Id == todo.Id)
                    .FirstOrDefaultAsync();

            if (existingTodo == null)
            {
                return NotFound();
            }

            _context.Entry(existingTodo).State = EntityState.Modified;
            existingTodo.Description = todo.Description;
            await _context.SaveChangesAsync();
            return Json(todo);
        }

        //Post: api/Items/Todo
        [HttpPost("Todo")]
        public async Task<IActionResult> AddTodo([FromBody] Todo todo)
        {
            _logger.LogDebug("Add Todo");
            await _context.Todo.AddAsync(todo);
            await _context.SaveChangesAsync();
            return Json(todo);
        }
    }
}
