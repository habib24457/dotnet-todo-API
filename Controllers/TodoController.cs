using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private readonly TodoContext _context;

        public TodoController(TodoContext todoContext)
        {
            _context = todoContext;
        }

        // GET: Transaction
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.TodoItems.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoItem todoItem)
        {

            var addTodo = new TodoItem
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };

            _context.TodoItems.Add(addTodo);

            return CreatedAtAction("CreateTodo", new { id = todoItem.Id }, todoItem);
        }

    }
}